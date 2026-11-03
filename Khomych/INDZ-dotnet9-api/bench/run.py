#!/usr/bin/env python3
"""Вимірювальний стенд: coldstart | idle | load | warmup. Результати дописуються у results/*.jsonl."""
import argparse, json, os, random, socket, subprocess as sp, threading, time, statistics as st
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
RES = ROOT / "results"; RES.mkdir(exist_ok=True)
NET, IP, PORT = "benchnet", "172.30.0.10", 8080
BASE = f"http://{IP}:{PORT}"
LIMITS = ["--memory=256m", "--memory-swap=256m", "--cpus=1.0", "--cpuset-cpus=0"]
IMAGES = {
    "controllers": "bench/controllers:slim",
    "minimal": "bench/minimal:slim",
    "aot": "bench/aot:slim",
    "control": "bench/control:scratch",
}
VARIANTS = ["controllers", "minimal", "aot"]
SCENARIOS = {
    "ping": "/api/ping",
    "items": "/api/items?category=books&minPrice=100&activeOnly=true",
    "cpu": "/api/cpu",
    "full": "/api/items",
}
LOADGEN_CPU = "1"
MEM = "/sys/fs/cgroup/memory/docker/{}/"
CPUA = "/sys/fs/cgroup/cpuacct/docker/{}/cpuacct.usage"
CFS = "/sys/fs/cgroup/cpu/docker/{}/cpu.stat"

def sh(*a, **k): return sp.run(a, capture_output=True, text=True, **k)
def append(name, rec):
    with open(RES / f"{name}.jsonl", "a") as f: f.write(json.dumps(rec, ensure_ascii=False) + "\n")
def now_iso(): return time.strftime("%Y-%m-%dT%H:%M:%S")
def cleanup(): sh("docker", "rm", "-f", "bench-sut")
def start(variant):
    cleanup()
    r = sh("docker", "run", "-d", "--name", "bench-sut", "--network", NET, "--ip", IP, *LIMITS, IMAGES[variant])
    if r.returncode: raise RuntimeError(r.stderr)
    return r.stdout.strip()

def http_get(path, timeout=0.05):
    """Один HTTP/1.1 GET. Повертає (status, bytes) або None."""
    s = socket.socket(); s.settimeout(timeout)
    try:
        s.connect((IP, PORT)); s.settimeout(30)
        s.sendall(f"GET {path} HTTP/1.1\r\nHost: b\r\nConnection: close\r\n\r\n".encode())
        chunks = []
        while True:
            b = s.recv(262144)
            if not b: break
            chunks.append(b)
        data = b"".join(chunks)
        return (int(data[9:12]), len(data)) if len(data) > 12 else None
    except OSError:
        return None
    finally:
        s.close()

def wait_ready(path, t0, limit=30.0):
    while time.perf_counter() - t0 < limit:
        r = http_get(path, 0.02)
        if r and r[0] == 200: return time.perf_counter()
        time.sleep(0.001)
    raise TimeoutError("not ready")

def memstat(cid):
    base = MEM.format(cid)
    usage = int(open(base + "memory.usage_in_bytes").read())
    s = dict(l.split() for l in open(base + "memory.stat"))
    return {"usage": usage, "ws": usage - int(s["total_inactive_file"]), "rss": int(s["total_rss"]),
            "cache": int(s["total_cache"]), "max_usage": int(open(base + "memory.max_usage_in_bytes").read()),
            "failcnt": int(open(base + "memory.failcnt").read())}
def cpu_ns(cid): return int(open(CPUA.format(cid)).read())
def throttled(cid):
    s = dict(l.split() for l in open(CFS.format(cid)))
    return {"nr_periods": int(s["nr_periods"]), "nr_throttled": int(s["nr_throttled"]), "throttled_ns": int(s["throttled_time"])}
def state(cid):
    return sh("docker", "inspect", "-f", "{{.State.Status}} {{.State.OOMKilled}} {{.State.ExitCode}}", cid).stdout.split()

def drop_caches():
    os.sync(); Path("/proc/sys/vm/drop_caches").write_text("3\n")

def cmd_coldstart(a):
    variants = VARIANTS + ["control"]
    for mode in ("warm_cache", "cold_cache"):
        order = [(v, i) for i in range(a.reps) for v in variants]
        random.Random(a.seed).shuffle(order)
        for v, i in order:
            cleanup(); time.sleep(0.3)
            if mode == "cold_cache": drop_caches(); time.sleep(0.2)
            path = "/" if v == "control" else "/api/ping"
            t0 = time.perf_counter()
            p = sp.Popen(["docker", "run", "-d", "--name", "bench-sut", "--network", NET, "--ip", IP, *LIMITS, IMAGES[v]],
                         stdout=sp.PIPE, stderr=sp.PIPE, text=True)
            t1 = wait_ready(path, t0)
            rec = {"variant": v, "mode": mode, "i": i, "ts": now_iso(), "first_ok_ms": (t1 - t0) * 1e3}
            if v != "control":
                for name in ("items", "cpu"):
                    t = time.perf_counter(); r = http_get(SCENARIOS[name], 5)
                    rec[f"first_{name}_ms"] = (time.perf_counter() - t) * 1e3
                    assert r and r[0] == 200, r
                t = time.perf_counter(); http_get(SCENARIOS["ping"], 5); rec["second_ping_ms"] = (time.perf_counter() - t) * 1e3
            p.wait()
            append("coldstart", rec)
            print(rec, flush=True)
    cleanup()

def cmd_idle(a):
    for i in range(a.reps):
        order = VARIANTS + ["control"]; random.Random(a.seed + i).shuffle(order)
        for v in order:
            if a.drop_caches: cleanup(); time.sleep(0.3); drop_caches(); time.sleep(0.2)
            cid = start(v); t0 = time.perf_counter()
            wait_ready("/" if v == "control" else "/api/ping", t0)
            time.sleep(a.settle)
            c0, tc = cpu_ns(cid), time.perf_counter(); samples = []
            for _ in range(a.window):
                samples.append(memstat(cid)); time.sleep(1)
            cpu = (cpu_ns(cid) - c0) / 1e9 / (time.perf_counter() - tc)
            rec = {"variant": v, "i": i, "ts": now_iso(), "ws_mb": st.median(s["ws"] for s in samples) / 2**20,
                   "rss_mb": st.median(s["rss"] for s in samples) / 2**20,
                   "cache_mb": st.median(s["cache"] for s in samples) / 2**20,
                   "startup_peak_mb": samples[-1]["max_usage"] / 2**20, "cpu_pct": cpu * 100}
            append(a.out, rec); print(rec, flush=True)
    cleanup()

def run_wrk(url, conns, dur, out):
    env = dict(os.environ, WRK_OUT=str(out))
    p = sp.run(["taskset", "-c", LOADGEN_CPU, "wrk", "-t1", f"-c{conns}", f"-d{dur}s", "--timeout", "10s",
                "-s", str(ROOT / "bench/report.lua"), url], capture_output=True, text=True, env=env)
    return json.loads(Path(out).read_text()), p.stdout

def one_load(a, v, sc, conns, rep, dur, warm):
    cid = start(v); t0 = time.perf_counter(); wait_ready("/api/ping", t0); time.sleep(1)
    tmp = RES / ".wrk.json"; url = BASE + SCENARIOS[sc]
    if warm: run_wrk(url, conns, warm, tmp)
    samples, stop = [], threading.Event()
    def sampler():
        while not stop.wait(0.5):
            try: samples.append(memstat(cid))
            except OSError: break
    th = threading.Thread(target=sampler, daemon=True); th.start()
    c0, th0, tt = cpu_ns(cid), throttled(cid), time.perf_counter()
    ru0 = os.times()
    w, _ = run_wrk(url, conns, dur, tmp)
    elapsed = time.perf_counter() - tt; ru1 = os.times()
    stop.set(); th.join()
    st_ = state(cid); alive = st_ and st_[0] == "running"
    rec = {"variant": v, "scenario": sc, "conns": conns, "rep": rep, "ts": now_iso(), "dur_s": dur, "warm_s": warm, **w,
           "rps": w["requests"] / (w["duration_us"] / 1e6), "state": st_, "wrk_cpu_pct": (ru1.children_user + ru1.children_system - ru0.children_user - ru0.children_system) / elapsed * 100}
    if alive:
        rec.update(cpu_pct=(cpu_ns(cid) - c0) / 1e9 / elapsed * 100)
        t1 = throttled(cid); rec["throttled_frac"] = (t1["nr_throttled"] - th0["nr_throttled"]) / max(1, t1["nr_periods"] - th0["nr_periods"])
        final = memstat(cid)
        rec.update(peak_ws_mb=max(s["ws"] for s in samples) / 2**20, peak_rss_mb=max(s["rss"] for s in samples) / 2**20,
                   mean_ws_mb=st.mean(s["ws"] for s in samples) / 2**20, max_usage_mb=final["max_usage"] / 2**20, failcnt=final["failcnt"])
        if a.post_idle:
            time.sleep(a.post_idle); rec["post_idle_ws_mb"] = memstat(cid)["ws"] / 2**20
    else:
        rec["crash_log"] = sh("docker", "logs", "--tail", "25", cid).stderr[-3000:]
        rec["dmesg"] = sh("dmesg", "--ctime").stdout[-800:]
    append(a.out, rec); print({k: rec.get(k) for k in ("variant", "scenario", "conns", "rep", "rps", "p50_us", "p99_us", "peak_ws_mb", "cpu_pct", "wrk_cpu_pct", "err_timeout", "err_read", "err_status", "state")}, flush=True)
    cleanup()

def cmd_load(a):
    cells = [(v, s, c) for v in a.variants.split(",") for s in a.scenarios.split(",") for c in map(int, a.conns.split(","))]
    for rep in a.rep_ids:
        order = cells[:]; random.Random(a.seed + rep).shuffle(order)
        for v, s, c in order: one_load(a, v, s, c, rep, a.duration, a.warm)

def cmd_warmup(a):
    tmp = RES / ".wrk.json"
    for rep in range(a.reps):
        cells = [(v, s) for v in VARIANTS for s in a.scenarios.split(",")]; random.Random(a.seed + rep).shuffle(cells)
        for v, s in cells:
            cid = start(v); t0 = time.perf_counter(); wait_ready("/api/ping", t0)
            for sec in range(a.seconds):
                w, _ = run_wrk(BASE + SCENARIOS[s], a.conns_w, 1, tmp)
                append("warmup", {"variant": v, "scenario": s, "rep": rep, "sec": sec, "rps": w["requests"] / (w["duration_us"] / 1e6), "p99_us": w["p99_us"], "ws_mb": memstat(cid)["ws"] / 2**20})
            print("warmup", v, s, rep, flush=True); cleanup()

if __name__ == "__main__":
    P = argparse.ArgumentParser(); S = P.add_subparsers(dest="c", required=True)
    p = S.add_parser("coldstart"); p.add_argument("--reps", type=int, default=20); p.add_argument("--seed", type=int, default=1); p.set_defaults(f=cmd_coldstart)
    p = S.add_parser("idle"); p.add_argument("--reps", type=int, default=5); p.add_argument("--seed", type=int, default=2); p.add_argument("--settle", type=int, default=30); p.add_argument("--window", type=int, default=5); p.add_argument("--drop-caches", dest="drop_caches", action="store_true"); p.add_argument("--out", default="idle"); p.set_defaults(f=cmd_idle)
    p = S.add_parser("load"); p.add_argument("--variants", default=",".join(VARIANTS)); p.add_argument("--scenarios", default="ping,items,cpu"); p.add_argument("--conns", default="100,1000")
    p.add_argument("--duration", type=int, default=120); p.add_argument("--warm", type=int, default=15); p.add_argument("--rep-ids", dest="rep_ids", type=lambda s: [int(x) for x in s.split(",")], default=[0]); p.add_argument("--seed", type=int, default=3); p.add_argument("--post-idle", type=int, default=20); p.add_argument("--out", default="load"); p.set_defaults(f=cmd_load)
    p = S.add_parser("warmup"); p.add_argument("--reps", type=int, default=3); p.add_argument("--seconds", type=int, default=30); p.add_argument("--conns-w", dest="conns_w", type=int, default=100); p.add_argument("--scenarios", default="ping,items"); p.add_argument("--seed", type=int, default=4); p.set_defaults(f=cmd_warmup)
    a = P.parse_args(); a.f(a)
