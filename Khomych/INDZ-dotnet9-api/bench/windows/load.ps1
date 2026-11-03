# Навантаження k6 + пікове споживання пам'яті. Перед запуском: docker compose up -d --build
# Короткий тест:  powershell -ExecutionPolicy Bypass -File bench\windows\load.ps1 -Duration 30s
# Повний тест:    powershell -ExecutionPolicy Bypass -File bench\windows\load.ps1
param(
    [string[]]$Services = @("controllers", "minimal", "aot"),
    [string[]]$Endpoints = @("ping", "items", "cpu"),
    [int[]]$Vus = @(100, 1000),
    [string]$Duration = "2m",
    [int]$Repeats = 3
)
# Continue: у Windows PowerShell stderr команди docker інакше зупиняв би скрипт
$ErrorActionPreference = "Continue"
$root = (Get-Location).Path
New-Item -ItemType Directory -Force results-local | Out-Null
$csv = "results-local\load.csv"
if (-not (Test-Path $csv)) { "service,endpoint,vus,repeat,rps,avg_ms,p95_ms,p99_ms,failed_rate,idle_mem_mb,peak_mem_mb" | Set-Content $csv }

function Get-MemMb([string]$container) {
    $raw = (docker stats --no-stream --format "{{.MemUsage}}" $container) -split "/" | Select-Object -First 1
    $raw = $raw.Trim()
    if ($raw -match "^([\d\.]+)\s*GiB$") { return [double]$Matches[1] * 1024 }
    if ($raw -match "^([\d\.]+)\s*MiB$") { return [double]$Matches[1] }
    if ($raw -match "^([\d\.]+)\s*KiB$") { return [double]$Matches[1] / 1024 }
    return 0
}

foreach ($rep in 1..$Repeats) { foreach ($svc in $Services) { foreach ($ep in $Endpoints) { foreach ($vu in $Vus) {
    Write-Host "== $svc / $ep / $vu VU / повтор $rep"
    docker compose restart $svc | Out-Null
    Start-Sleep -Seconds 5
    $container = "apibench-$svc-1"
    $idle = Get-MemMb $container

    $sampler = Start-Job -ScriptBlock {
        param($c)
        while ($true) { docker stats --no-stream --format "{{.MemUsage}}" $c; Start-Sleep -Seconds 1 }
    } -ArgumentList $container

    $summary = "summary-$svc-$ep-$vu-$rep.json"
    docker run --rm --network apibench_default `
        -v "${root}\bench:/scripts:ro" -v "${root}\results-local:/out" `
        -e "BASE=http://${svc}:8080" -e "EP=$ep" -e "VUS=$vu" -e "DURATION=$Duration" `
        grafana/k6 run --quiet --summary-export "/out/$summary" /scripts/k6-load.js

    Stop-Job $sampler
    $peak = 0.0
    foreach ($line in (Receive-Job $sampler)) {
        $v = ($line -split "/")[0].Trim()
        if ($v -match "^([\d\.]+)\s*MiB$") { $peak = [math]::Max($peak, [double]$Matches[1]) }
        elseif ($v -match "^([\d\.]+)\s*GiB$") { $peak = [math]::Max($peak, [double]$Matches[1] * 1024) }
    }
    Remove-Job $sampler -Force

    $m = (Get-Content "results-local\$summary" -Raw | ConvertFrom-Json).metrics
    $d = $m.http_req_duration
    $row = "$svc,$ep,$vu,$rep,{0},{1},{2},{3},{4},{5},{6}" -f `
        [math]::Round($m.http_reqs.rate, 1).ToString([cultureinfo]::InvariantCulture), [math]::Round($d.avg, 2).ToString([cultureinfo]::InvariantCulture), [math]::Round($d.'p(95)', 2).ToString([cultureinfo]::InvariantCulture), [math]::Round($d.'p(99)', 2).ToString([cultureinfo]::InvariantCulture), $m.http_req_failed.value.ToString([cultureinfo]::InvariantCulture), [math]::Round($idle, 1).ToString([cultureinfo]::InvariantCulture), [math]::Round($peak, 1).ToString([cultureinfo]::InvariantCulture)
    $row | Add-Content $csv
    Write-Host $row
}}}}
Write-Host "Зведення: $csv"
