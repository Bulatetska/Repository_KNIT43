using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Numerics;

// Службовий запуск для вимірювання холодного старту
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
    int n = level == "low" ? 500 : level == "medium" ? 2000 : 8000;
    Header("Задача 1: матриці", level);
    Console.WriteLine($"Розмір: {n} x {n}; SIMD: {Vector.IsHardwareAccelerated}, {Vector<float>.Count} float у векторі");
    float[] a = new float[n * n], b = new float[n * n], c = new float[n * n];
    Fill(a, b, n);
    float[] smallA = new float[4096], smallB = new float[4096], smallC = new float[4096];
    Fill(smallA, smallB, 64);
    Test(() => Multiply(a, b, c, n), () => Multiply(smallA, smallB, smallC, 64), repeats);
    foreach (int row in new[] { 0, n / 2, n - 1 })
        foreach (int col in new[] { 0, n / 2, n - 1 })
        {
            double expected = 0;
            for (int k = 0; k < n; k++) expected += (double)a[row * n + k] * b[k * n + col];
            if (Math.Abs(c[row * n + col] - expected) > Math.Max(0.0001, Math.Abs(expected) * 0.0001))
                throw new Exception("Неправильний результат множення.");
        }
    Console.WriteLine("Перевірка: OK");
}
catch (OutOfMemoryException)
{
    Console.WriteLine("Недостатньо RAM. Тест не завершено.");
    Environment.ExitCode = 1;
}

static void Fill(float[] a, float[] b, int n)
{
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
        {
            a[i * n + j] = (i + j) % 17 / 16.0f;
            b[i * n + j] = (i * 3 + j) % 13 / 16.0f;
        }
}


static void Multiply(float[] a, float[] b, float[] c, int n)
{
    Array.Clear(c);
    int width = Vector<float>.Count;
    for (int ii = 0; ii < n; ii += 64)
        for (int kk = 0; kk < n; kk += 64)
            for (int jj = 0; jj < n; jj += 64)
                for (int i = ii; i < Math.Min(ii + 64, n); i++)
                    for (int k = kk; k < Math.Min(kk + 64, n); k++)
                    {
                        int end = Math.Min(jj + 64, n);
                        float value = a[i * n + k];
                        var va = new Vector<float>(value);
                        int j = jj;
                        for (; j <= end - width; j += width)
                        {
                            var vb = new Vector<float>(b, k * n + j);
                            var vc = new Vector<float>(c, i * n + j);
                            (vc + va * vb).CopyTo(c, i * n + j);
                        }
                        for (; j < end; j++) c[i * n + j] += value * b[k * n + j];
                    }
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
    var clock = new Stopwatch();
    long before = GC.GetTotalAllocatedBytes(true);

    clock.Start();
    work();
    clock.Stop();
    long allocated = GC.GetTotalAllocatedBytes(true) - before;

    using Process process = Process.GetCurrentProcess();
    Console.WriteLine($"{label,-20} {clock.Elapsed.TotalMilliseconds,12:F2} {allocated / 1048576.0,14:F2} {process.WorkingSet64 / 1048576.0,12:F2}");
    return clock.Elapsed.TotalMilliseconds;
}

static void Warmup(Action work)
{
    var clock = Stopwatch.StartNew();
    int calls = 0;
    do { work(); calls++; } while (calls < 32 || clock.ElapsedMilliseconds < 500);
    Thread.Sleep(150); // Час для фонової JIT-оптимізації
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
