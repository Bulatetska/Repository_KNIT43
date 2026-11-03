#!/usr/bin/env python3
"""Зведення сирих вимірювань із results/*.jsonl у results/summary.json. Запуск повторюваний."""
import json, math, statistics as st
from collections import defaultdict
from pathlib import Path
RES = Path(__file__).resolve().parent.parent / "results"
def rows(n):
    p = RES / f"{n}.jsonl"
    return [json.loads(l) for l in p.read_text().splitlines()] if p.exists() else []
def q(v, p):
    v = sorted(v); k = (len(v) - 1) * p; f = math.floor(k); c = min(f + 1, len(v) - 1)
    return v[f] + (v[c] - v[f]) * (k - f)
def ci95(v):
    """Напівширина 95% довірчого інтервалу середнього (t-розподіл)."""
    n = len(v)
    if n < 2: return None
    t = {2: 12.706, 3: 4.303, 4: 3.182, 5: 2.776, 20: 2.093}.get(n, 2.0)
    return t * st.stdev(v) / math.sqrt(n)
def desc(v):
    return dict(n=len(v), mean=st.mean(v), median=st.median(v), p05=q(v, .05), p95=q(v, .95), min=min(v), max=max(v),
                sd=st.stdev(v) if len(v) > 1 else 0.0, ci95=ci95(v))
S = {}
cold = rows("coldstart"); g = defaultdict(list)
for r in cold: g[r["variant"], r["mode"]].append(r)
S["coldstart"] = {f"{v}|{m}": {"first_ok_ms": desc([x["first_ok_ms"] for x in rs]),
    **{k: desc([x[k] for x in rs]) for k in ("first_items_ms", "first_cpu_ms", "second_ping_ms") if k in rs[0]}} for (v, m), rs in g.items()}
for m in ("warm_cache", "cold_cache"):
    if f"control|{m}" in S["coldstart"]:
        base = S["coldstart"][f"control|{m}"]["first_ok_ms"]["median"]
        for v in ("controllers", "minimal", "aot"):
            if f"{v}|{m}" in S["coldstart"]:
                S["coldstart"][f"{v}|{m}"]["app_only_ms"] = S["coldstart"][f"{v}|{m}"]["first_ok_ms"]["median"] - base
g = defaultdict(list)
for r in rows("idle"): g[r["variant"]].append(r)
S["idle"] = {v: {k: desc([x[k] for x in rs]) for k in ("ws_mb", "rss_mb", "cache_mb", "startup_peak_mb", "cpu_pct")} for v, rs in g.items()}
g = defaultdict(list)
for r in rows("warmup"): g[r["variant"], r["scenario"], r["sec"]].append(r)
S["warmup"] = {f"{v}|{s}|{t}": {"rps": st.mean(x["rps"] for x in rs), "p99_ms": st.mean(x["p99_us"] for x in rs) / 1e3, "ws_mb": st.mean(x["ws_mb"] for x in rs), "n": len(rs)} for (v, s, t), rs in g.items()}
g = defaultdict(list)
for r in rows("load"): g[r["variant"], r["scenario"], r["conns"]].append(r)
L = {}
for (v, s, c), rs in g.items():
    ok = [x for x in rs if x.get("cpu_pct") is not None]
    e = {"runs": len(rs), "crashed": sum(1 for x in rs if x["state"][0] != "running"), "oom": sum(1 for x in rs if x["state"][1:2] == ["true"]),
         "exit_codes": sorted({x["state"][2] for x in rs if x["state"][0] != "running"}),
         "timeouts": sum(x["err_timeout"] for x in rs), "read_err": sum(x["err_read"] for x in rs), "connect_err": sum(x["err_connect"] for x in rs), "status_err": sum(x["err_status"] for x in rs)}
    for k in ("rps", "lat_mean_us", "p50_us", "p90_us", "p95_us", "p99_us", "wrk_cpu_pct"):
        vals = [x[k] for x in rs if x["requests"] > 0]
        if vals: e[k] = desc(vals)
    for k in ("cpu_pct", "peak_ws_mb", "peak_rss_mb", "mean_ws_mb", "max_usage_mb", "post_idle_ws_mb", "throttled_frac"):
        vals = [x[k] for x in ok if k in x]
        if vals: e[k] = desc(vals)
    L[f"{v}|{s}|{c}"] = e
S["load"] = L
(RES / "summary.json").write_text(json.dumps(S, ensure_ascii=False, indent=1))
if __name__ == "__main__":
    for k, v in S["coldstart"].items():
        print(k, {a: round(b["median"], 1) for a, b in v.items() if isinstance(b, dict)}, "app", round(v.get("app_only_ms", 0), 1))
    for k, v in S["idle"].items(): print(k, {a: round(b["median"], 2) for a, b in v.items()})
    for k, e in L.items():
        print(k, "rps", round(e["rps"]["mean"], 1) if "rps" in e else None, "±", round(e["rps"]["ci95"] or 0, 1) if "rps" in e else "", "p95ms", round(e["p95_us"]["mean"] / 1e3, 1) if "p95_us" in e else None, "p99ms", round(e["p99_us"]["mean"] / 1e3, 1) if "p99_us" in e else None, "peakWS", round(e["peak_ws_mb"]["mean"], 1) if "peak_ws_mb" in e else None, "crash", e["crashed"], "to", e["timeouts"], "rd", e["read_err"])
