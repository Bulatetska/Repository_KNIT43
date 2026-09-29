using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

if (args.Length == 1 && args[0] == "--start")
{
    Console.WriteLine("READY");
    return;
}
Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
string level = args.Length > 0 ? args[0] : "low";
int repeats = args.Length > 1 ? int.Parse(args[1]) : 3;
if (args.Length > 2 || (level != "low" && level != "medium" && level != "high") || repeats < 1 || repeats > 20)
    throw new ArgumentException("Вкажи low, medium або high; кількість повторів: 1–20.");

try
{
    int count = level == "low" ? 1000 : level == "medium" ? 100_000 : 10_000_000;
    int workers = level == "low" ? 10 : level == "medium" ? 100 : 1000;
    Header("Задача 4: асинхронні операції", level);
    Console.WriteLine($"Операцій: {count}; конкурентність: {workers}; Channel + Task.WhenAll");
    Test(() => Run(count, workers), () => Run(100, 10), repeats);
    Console.WriteLine("Перевірка: OK");
}
catch (OutOfMemoryException)
{
    Console.WriteLine("Недостатньо RAM. Тест не завершено.");
    Environment.ExitCode = 1;
}

static void Run(int count, int workers)
{
    long sum = ProcessAsync(count, workers).GetAwaiter().GetResult();
    if (sum != (long)count * (count - 1) / 2) throw new Exception("Втрачено операції.");
}

static async Task<long> ProcessAsync(int count, int workers)
{
    var channel = Channel.CreateBounded<int>(workers * 2);
    Task<long>[] consumers = new Task<long>[workers];
    for (int i = 0; i < workers; i++) consumers[i] = Consume(channel.Reader);
    for (int i = 0; i < count; i++) await channel.Writer.WriteAsync(i);
    channel.Writer.Complete();
    long[] results = await Task.WhenAll(consumers);
    long sum = 0;
    foreach (long value in results) sum += value;
    return sum;
}

static async Task<long> Consume(ChannelReader<int> reader)
{
    long sum = 0;
    while (await reader.WaitToReadAsync())
        while (reader.TryRead(out int id)) sum += await Operation(id);
    return sum;
}

static async ValueTask<long> Operation(int id)
{
    await Task.Delay(1);
    return id;
}

// Нижче — тільки вимірювання часу й пам'яті.
static void Header(string title, string level)
{
    string mode = RuntimeFeature.IsDynamicCodeSupported ? "JIT" : "Native AOT";
    string exe = Environment.ProcessPath!;
    bool viaDotnet = Path.GetFileNameWithoutExtension(exe).Equals("dotnet", StringComparison.OrdinalIgnoreCase);
    double[] starts = new double[3];
    for (int i = 0; i < 3; i++)
    {
        var info = new ProcessStartInfo(exe) { UseShellExecute = false, RedirectStandardOutput = true };
        if (viaDotnet) info.ArgumentList.Add(Environment.GetCommandLineArgs()[0]);
        info.ArgumentList.Add("--start");
        var clock = Stopwatch.StartNew();
        using Process child = Process.Start(info)!;
        string? ready = child.StandardOutput.ReadLine();
        starts[i] = clock.Elapsed.TotalMilliseconds;
        child.WaitForExit();
        if (ready != "READY" || child.ExitCode != 0) throw new Exception("Помилка перевірки старту.");
    }
    Array.Sort(starts);
    string size = viaDotnet ? "запусти готовий EXE" : $"{new FileInfo(exe).Length / 1048576.0:F2} MiB";
    Console.WriteLine($"{title} | {mode} | {level} | .NET {Environment.Version}");
    Console.WriteLine($"Холодний старт: {starts[1]:F2} мс | EXE: {size}");
}

static double Measure(string label, Action work)
{
    GC.Collect(); // Прибираємо попередні дані поза таймером.
    int first = ThreadPool.ThreadCount, peak = first;
    double peakMs = 0;
    bool stop = false;
    long start = Stopwatch.GetTimestamp();
    var monitor = new Thread(() =>
    {
        while (!Volatile.Read(ref stop))
        {
            int threads = ThreadPool.ThreadCount;
            if (threads > peak)
            {
                peak = threads;
                peakMs = Stopwatch.GetElapsedTime(start).TotalMilliseconds;
            }
            Thread.Sleep(10);
        }
    }) { IsBackground = true };
    monitor.Start();
    var clock = new Stopwatch();
    long before = GC.GetTotalAllocatedBytes(true);

    clock.Start();
    try { work(); }
    finally { Volatile.Write(ref stop, true); }
    clock.Stop();
    long allocated = GC.GetTotalAllocatedBytes(true) - before;

    monitor.Join();
    using Process process = Process.GetCurrentProcess();
    Console.WriteLine($"{label,-20} {clock.Elapsed.TotalMilliseconds,12:F2} {allocated / 1048576.0,14:F2} {process.WorkingSet64 / 1048576.0,12:F2}");
    Console.WriteLine($"  ThreadPool: {first} -> {peak} потоків; пік через {peakMs:F2} мс");
    return clock.Elapsed.TotalMilliseconds;
}

static void Warmup(Action work)
{
    var clock = Stopwatch.StartNew();
    int calls = 0;
    do { work(); calls++; } while (calls < 32 || clock.ElapsedMilliseconds < 500);
    Thread.Sleep(150); // Час для фонової JIT-оптимізації.
}

static void Finish(string name, double[] times)
{
    Array.Sort(times);
    int mid = times.Length / 2;
    double median = times.Length % 2 == 1 ? times[mid] : (times[mid - 1] + times[mid]) / 2;
    using Process process = Process.GetCurrentProcess();
    Console.WriteLine($"{name}: медіана {median:F2} мс | пік RAM процесу: {process.PeakWorkingSet64 / 1048576.0:F2} MiB");
}

static void Test(Action work, Action warmup, int repeats)
{
    Console.WriteLine("Запуск                    Час, мс  Виділено, MiB     RAM, MiB");
    Measure("Перший виклик", work);
    Warmup(warmup);
    double[] times = new double[repeats];
    for (int i = 0; i < repeats; i++) times[i] = Measure($"Повтор {i + 1}", work);
    Finish("Прогріті повтори", times);
}
