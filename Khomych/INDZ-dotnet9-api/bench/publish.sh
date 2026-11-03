#!/usr/bin/env bash
# Публікація всіх трьох варіантів. RID за замовчуванням linux-x64 (SDK від Microsoft);
# для SDK з архіву Ubuntu: RID=ubuntu.25.10-x64 ./bench/publish.sh
set -euo pipefail
export DOTNET_CLI_TELEMETRY_OPTOUT=1 DOTNET_NOLOGO=1
RID="${RID:-linux-x64}"
cd "$(dirname "$0")/.."
rm -rf publish
dotnet publish src/Api.Controllers -c Release -o publish/controllers -r "$RID" --self-contained false
dotnet publish src/Api.Minimal     -c Release -o publish/minimal     -r "$RID" --self-contained false
dotnet publish src/Api.MinimalAot  -c Release -o publish/aot         -r "$RID"
