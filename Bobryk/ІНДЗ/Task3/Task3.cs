using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

// Службовий запуск для вимірювання холодного старту.
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
    int count = level == "low" ? 1000 : level == "medium" ? 100_000 : 5_000_000;
    Header("Задача 3: JSON", level);
    #if NATIVE_AOT || SOURCEGEN
    Console.WriteLine($"Об'єктів: {count}; Source Generator");
    #else
    Console.WriteLine($"Об'єктів: {count}; Reflection");
    #endif
    UserSession[] data = CreateData(count);
    double[] writeTimes = new double[repeats], readTimes = new double[repeats];
    long jsonSize = 0;
    Console.WriteLine("Запуск                    Час, мс  Виділено, MiB     RAM, MiB");
    for (int i = 0; i <= repeats; i++)
    {
        string label = i == 0 ? "Перший" : $"Повтор {i}";
        using (var json = new BlockStream())
        {
            double write = Measure(label + ": запис", () => Save(json, data));
            jsonSize = json.Length;
            json.Position = 0;
            UserSession[]? restored = null;
            double read = Measure(label + ": читання", () => restored = Load(json));
            if (restored!.Length != count) throw new Exception("Неправильна кількість об'єктів.");
            for (int j = 0; j < count; j++)
                if (restored[j].Id != j) throw new Exception("Неправильні ID у JSON.");
            if (restored[^1].Notes != data[^1].Notes || restored[^1].SessionId != data[^1].SessionId)
                throw new Exception("JSON змінив дані.");
            restored = null;
            if (i > 0) { writeTimes[i - 1] = write; readTimes[i - 1] = read; }
        }
        if (i == 0)
        {
            UserSession[] small = CreateData(32);
            Warmup(() =>
            {
                using var buffer = new BlockStream();
                Save(buffer, small);
                buffer.Position = 0;
                GC.KeepAlive(Load(buffer));
            });
        }
    }
    Console.WriteLine($"JSON: {jsonSize / 1048576.0:F2} MiB | Перевірка: OK");
    Finish("Запис", writeTimes);
    Finish("Читання", readTimes);
}
catch (OutOfMemoryException)
{
    Console.WriteLine("Недостатньо RAM. Тест не завершено.");
    Environment.ExitCode = 1;
}

static UserSession[] CreateData(int count)
{
    var data = new UserSession[count];
    DateTime date = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    for (int i = 0; i < count; i++)
        data[i] = new UserSession
        {
            Id = i,
            SessionId = new Guid(i, 123, 456, 1, 2, 3, 4, 5, 6, 7, 8),
            Name = "User_" + i.ToString("D7"),
            Email = "user_" + i.ToString("D7") + "@example.com",
            CreatedAt = date.AddSeconds(i),
            IsActive = i % 2 == 0,
            Score = i % 100,
            Country = "UA",
            Tags = new List<string> { "study", "csharp", "benchmark" },
            Notes = new string((char)('a' + i % 26), 255)
        };
    return data;
}

static void Save(Stream stream, UserSession[] data)
{
#if NATIVE_AOT || SOURCEGEN
    JsonSerializer.Serialize(stream, data, SessionContext.Default.UserSessionArray);
#else
    JsonSerializer.Serialize(stream, data);
#endif
}

static UserSession[] Load(Stream stream)
{
#if NATIVE_AOT || SOURCEGEN
    return JsonSerializer.Deserialize(stream, SessionContext.Default.UserSessionArray)!;
#else
    return JsonSerializer.Deserialize<UserSession[]>(stream)!;
#endif
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

public class UserSession
{
    public long Id { get; set; }
    public Guid SessionId { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
    public int Score { get; set; }
    public string Country { get; set; } = "";
    public List<string> Tags { get; set; } = new List<string>();
    public string Notes { get; set; } = "";
}

[JsonSerializable(typeof(UserSession[]))]
internal partial class SessionContext : JsonSerializerContext { }

// Зберігає весь JSON у RAM. Блоки потрібні для документа понад 2 GB.
class BlockStream : Stream
{
    const int Size = 1024 * 1024;
    readonly List<byte[]> blocks = new List<byte[]>();
    long position, length;
    public override bool CanRead => true;
    public override bool CanWrite => true;
    public override bool CanSeek => true;
    public override long Length => length;
    public override long Position
    {
        get => position;
        set => position = value >= 0 && value <= length ? value : throw new ArgumentOutOfRangeException();
    }
    public override void Flush() { }
    public override void Write(byte[] b, int offset, int count) => Write(b.AsSpan(offset, count));
    public override void Write(ReadOnlySpan<byte> data)
    {
        while (!data.IsEmpty)
        {
            int block = checked((int)(position / Size)), offset = (int)(position % Size);
            if (block == blocks.Count) blocks.Add(new byte[Size]);
            int count = Math.Min(data.Length, Size - offset);
            data.Slice(0, count).CopyTo(blocks[block].AsSpan(offset));
            data = data.Slice(count);
            position += count;
            length = Math.Max(length, position);
        }
    }
    public override int Read(byte[] b, int offset, int count) => Read(b.AsSpan(offset, count));
    public override int Read(Span<byte> data)
    {
        int total = 0;
        while (!data.IsEmpty && position < length)
        {
            int block = checked((int)(position / Size)), offset = (int)(position % Size);
            int count = (int)Math.Min(Math.Min(data.Length, Size - offset), length - position);
            blocks[block].AsSpan(offset, count).CopyTo(data);
            data = data.Slice(count);
            position += count;
            total += count;
        }
        return total;
    }
    public override long Seek(long offset, SeekOrigin origin)
    {
        Position = origin == SeekOrigin.Begin ? offset : origin == SeekOrigin.Current ? position + offset : length + offset;
        return position;
    }
    public override void SetLength(long value) => throw new NotSupportedException();
    protected override void Dispose(bool disposing)
    {
        if (disposing) blocks.Clear();
        base.Dispose(disposing);
    }
}
