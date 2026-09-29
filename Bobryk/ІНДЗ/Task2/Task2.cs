using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Runtime;


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
    int count = level == "low" ? 100_000 : level == "medium" ? 10_000_000 : 100_000_000;
    Header("Задача 2: пам'ять і GC", level);
    Console.WriteLine($"Об'єктів: {count}; LOH: {level == "high"}");
    Test(() => Allocate(count, level == "high"), () => Allocate(4000, false), repeats);
    Console.WriteLine("Перевірка: OK");
}
catch (OutOfMemoryException)
{
    Console.WriteLine("Недостатньо RAM. Тест не завершено.");
    Environment.ExitCode = 1;
}

static void Allocate(int count, bool large)
{
    Node?[] roots = new Node?[large ? 512 : 64];
    byte[]?[] buffers = large ? new byte[35_000][] : Array.Empty<byte[]>();
    long sum = 0;
    int batch = 0;
    for (int start = 0; start < count; start += 2000)
    {
        Node[] nodes = new Node[Math.Min(2000, count - start)];
        for (int i = 0; i < nodes.Length; i++)
        {
            long id = start + i;
            nodes[i] = new Node { Id = id, A = id + 1, B = id + 2, C = id + 3, D = id + 4, E = id + 5 };
            sum += nodes[i].Id;
        }
        // Будуємо дерево з посилань між об'єктами
        for (int i = 0; i < nodes.Length; i++)
        {
            if (2 * i + 1 < nodes.Length) nodes[i].Left = nodes[2 * i + 1];
            if (2 * i + 2 < nodes.Length) nodes[i].Right = nodes[2 * i + 2];
        }
        int slot = batch % roots.Length;
        int victim = (slot + 4) % roots.Length;
        if (roots[victim] != null) roots[victim]!.Left = null; // Від'єднуємо гілку
        roots[slot] = batch % 4 == 0 ? nodes[0] : null; // Частина дерев стає сміттям
        if (large)
        {
            byte[] block = new byte[100_000]; // Великий об'єкт потрапляє в LOH
            Array.Fill(block, (byte)(batch % 251));
            buffers[batch % buffers.Length] = block;
        }
        batch++;
    }
    if (large)
    {
        for (int i = 0; i < buffers.Length; i += 2) buffers[i] = null;
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
        GC.Collect(2, GCCollectionMode.Forced, blocking: true, compacting: true);
    }
    GC.KeepAlive(roots);
    GC.KeepAlive(buffers);
    if (sum != (long)count * (count - 1) / 2) throw new Exception("Неправильна сума ID.");
}

// Нижче тільки вимірювання часу й пам'яті
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
    GC.Collect(); // Прибираємо попередні дані поза таймером
    var clock = new Stopwatch();
    long before = GC.GetTotalAllocatedBytes(true);
    int g0 = GC.CollectionCount(0), g1 = GC.CollectionCount(1), g2 = GC.CollectionCount(2);
    TimeSpan pause = GC.GetTotalPauseDuration();
    clock.Start();
    work();
    clock.Stop();
    long allocated = GC.GetTotalAllocatedBytes(true) - before;
    g0 = GC.CollectionCount(0) - g0; g1 = GC.CollectionCount(1) - g1; g2 = GC.CollectionCount(2) - g2;
    double pauseMs = (GC.GetTotalPauseDuration() - pause).TotalMilliseconds;
    using Process process = Process.GetCurrentProcess();
    Console.WriteLine($"{label,-20} {clock.Elapsed.TotalMilliseconds,12:F2} {allocated / 1048576.0,14:F2} {process.WorkingSet64 / 1048576.0,12:F2}   {g0}/{g1}/{g2}   {pauseMs:F2}");
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
    Console.WriteLine("Запуск                    Час, мс  Виділено, MiB     RAM, MiB   GC 0/1/2   Пауза, мс");
    Measure("Перший виклик", work);
    Warmup(warmup);
    double[] times = new double[repeats];
    for (int i = 0; i < repeats; i++) times[i] = Measure($"Повтор {i + 1}", work);
    Finish("Прогріті повтори", times);
}

// Приблизно 80 байт на об'єкт x64; Left і Right утворюють граф.
class Node
{
    public long Id, A, B, C, D, E;
    public Node? Left, Right;
}
