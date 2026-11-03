# Холодний старт: час від docker run до першої відповіді 200 на /api/ping.
# Запуск із кореня проекту: powershell -ExecutionPolicy Bypass -File bench\windows\cold-start.ps1
param(
    [string[]]$Images = @("bench/controllers:chiseled", "bench/minimal:chiseled", "bench/aot:chiseled"),
    [int]$Runs = 20,
    [int]$Port = 18080
)
# Continue: у Windows PowerShell stderr команди docker інакше зупиняв би скрипт
$ErrorActionPreference = "Continue"
New-Item -ItemType Directory -Force results-local | Out-Null
$csv = "results-local\cold-start.csv"
"image,run,ms" | Set-Content $csv
Add-Type -AssemblyName System.Net.Http
# Паралельні спроби: відмова в з'єднанні на localhost у Windows триває близько 2 с,
# тому одна послідовна спроба з таймаутом дала б похибку в сотні мілісекунд.
[System.Net.ServicePointManager]::DefaultConnectionLimit = 1000
$http = [System.Net.Http.HttpClient]::new()
$http.Timeout = [TimeSpan]::FromSeconds(5)
$http.DefaultRequestHeaders.ConnectionClose = $true
$url = "http://localhost:$Port/api/ping"
foreach ($image in $Images) {
    $values = @()
    for ($i = 1; $i -le $Runs; $i++) {
        docker rm -f cs-test 2>$null | Out-Null
        Start-Sleep -Milliseconds 300
        $psi = [System.Diagnostics.ProcessStartInfo]::new("docker", "run -d --name cs-test -p ${Port}:8080 --memory=256m --memory-swap=256m --cpus=1.0 $image")
        $psi.UseShellExecute = $false
        $psi.CreateNoWindow = $true
        $sw = [System.Diagnostics.Stopwatch]::StartNew()
        $proc = [System.Diagnostics.Process]::Start($psi)
        $tasks = New-Object System.Collections.ArrayList
        $ms = $null
        while ($null -eq $ms -and $sw.Elapsed.TotalSeconds -lt 30) {
            [void]$tasks.Add($http.GetAsync($url))
            Start-Sleep -Milliseconds 5
            foreach ($t in @($tasks)) {
                if ($t.IsCompleted) {
                    if ($t.Status -eq "RanToCompletion" -and $t.Result.IsSuccessStatusCode) {
                        $ms = [math]::Round($sw.Elapsed.TotalMilliseconds, 1)
                        break
                    }
                    $tasks.Remove($t)
                }
            }
        }
        $proc.WaitForExit()
        if ($null -eq $ms) { throw "$image не відповів за 30 с" }
        "$image,$i,$ms" | Add-Content $csv
        $values += $ms
    }
    $sorted = $values | Sort-Object
    $median = $sorted[[int][math]::Floor($sorted.Count / 2)]
    Write-Host ("{0}: медіана {1} мс, мін. {2}, макс. {3}" -f $image, $median, $sorted[0], $sorted[-1])
}
docker rm -f cs-test 2>$null | Out-Null
Write-Host "Сирі дані: $csv"
