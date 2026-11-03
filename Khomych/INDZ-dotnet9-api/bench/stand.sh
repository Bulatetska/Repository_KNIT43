#!/usr/bin/env bash
# Закріплює фонові процеси за CPU1: контейнер під тестом працює на CPU0, wrk і Docker на CPU1.
for p in $(pgrep -x dockerd) $(pgrep -x containerd) $(pgrep -f containerd-shim); do taskset -acp 1 "$p" >/dev/null 2>&1; done
docker network inspect benchnet >/dev/null 2>&1 || docker network create --subnet 172.30.0.0/24 benchnet >/dev/null
