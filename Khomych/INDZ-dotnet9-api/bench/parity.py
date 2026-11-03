#!/usr/bin/env python3
"""Перевіряє, що всі варіанти API функціонально однакові: той самий статус і те саме тіло."""
import json, re, subprocess as sp, sys, time, urllib.request, urllib.error
IP = "172.30.0.10"; proxy = urllib.request.build_opener(urllib.request.ProxyHandler({}))
BODY = {"name": "Test", "category": "books", "price": 19.99, "stock": 5, "active": True, "tags": ["a", "b"]}
STEPS = [("GET", "/api/ping", None), ("GET", "/api/items/1", None), ("GET", "/api/items/999999", None),
         ("GET", "/api/items?category=books&minPrice=100&activeOnly=true", None), ("GET", "/api/items", None),
         ("POST", "/api/items", BODY), ("GET", "/api/items/10001", None), ("PUT", "/api/items/10001", {**BODY, "name": "Upd"}),
         ("PUT", "/api/items/999999", BODY), ("DELETE", "/api/items/10001", None), ("DELETE", "/api/items/10001", None),
         ("GET", "/api/items/10001", None), ("GET", "/api/cpu", None), ("GET", "/api/cpu?input=abc&rounds=5", None), ("GET", "/api/cpu?rounds=0", None)]
def norm(b):
    b = re.sub(r'"createdUtc":"20(2[5-9])[^"]*"', '"createdUtc":"<now>"', b)
    return re.sub(r'("token":"[^.]+\.)[^"]+"', r'\1<jwt>"', b)
out = {}
for v in sys.argv[1:] or ["controllers", "minimal", "aot"]:
    sp.run(["docker", "rm", "-f", "bench-sut"], capture_output=True)
    sp.run(["docker", "run", "-d", "--name", "bench-sut", "--network", "benchnet", "--ip", IP, "--memory=256m", f"bench/{v}:slim"], capture_output=True, check=True)
    time.sleep(2); out[v] = []
    for m, path, body in STEPS:
        req = urllib.request.Request(f"http://{IP}:8080{path}", method=m, data=json.dumps(body).encode() if body else None, headers={"Content-Type": "application/json"})
        try:
            r = proxy.open(req, timeout=5); code, data = r.status, r.read().decode(); loc = r.headers.get("Location")
        except urllib.error.HTTPError as e:
            code, data, loc = e.code, e.read().decode(), None
        out[v].append((m, path, code, norm(data), loc))
sp.run(["docker", "rm", "-f", "bench-sut"], capture_output=True)
ref = out["controllers"]; bad = 0
for i, st in enumerate(ref):
    row = {v: (out[v][i][2], len(out[v][i][3])) for v in out}
    same = all(out[v][i][2:] == st[2:] for v in out); bad += not same
    print("OK  " if same else "DIFF", st[0], st[1][:48], row)
    if not same:
        for v in out: print("    ", v, out[v][i][2], out[v][i][3][:160], out[v][i][4])
print("mismatches:", bad)
