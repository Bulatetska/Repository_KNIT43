#!/usr/bin/env bash
cd "$(dirname "$0")/.."; bash bench/stand.sh
python3 bench/run.py coldstart --reps 20 > results/log-coldstart.txt 2>&1
python3 bench/run.py idle --reps 5 > results/log-idle.txt 2>&1
python3 bench/run.py warmup --reps 3 > results/log-warmup.txt 2>&1
python3 bench/run.py load --rep-ids 0 > results/log-load.txt 2>&1
python3 bench/run.py load --out load --rep-ids 0 --scenarios full --duration 60 --warm 10 --post-idle 0 >> results/log-load.txt 2>&1
