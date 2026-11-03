-- wrk: записує підсумок одного прогону як JSON у файл $WRK_OUT
done = function(summary, latency, requests)
  local f = io.open(os.getenv("WRK_OUT"), "w")
  f:write(string.format(
    '{"duration_us":%d,"requests":%d,"bytes":%d,"err_connect":%d,"err_read":%d,"err_write":%d,"err_status":%d,"err_timeout":%d,' ..
    '"lat_min_us":%d,"lat_mean_us":%.2f,"lat_stdev_us":%.2f,"lat_max_us":%d,"p50_us":%d,"p90_us":%d,"p95_us":%d,"p99_us":%d,"p999_us":%d}\n',
    summary.duration, summary.requests, summary.bytes, summary.errors.connect, summary.errors.read,
    summary.errors.write, summary.errors.status, summary.errors.timeout,
    latency.min, latency.mean, latency.stdev, latency.max,
    latency:percentile(50), latency:percentile(90), latency:percentile(95), latency:percentile(99), latency:percentile(99.9)))
  f:close()
end
