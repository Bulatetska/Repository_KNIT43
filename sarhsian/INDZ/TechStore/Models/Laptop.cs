namespace TechStore.Models;
public sealed class Laptop : ProductBase
{
    public string Cpu { get; }
    public int RamGb { get; }

    public Laptop(string name, decimal price, string cpu, int ramGb)
        : base(name, price)
    {
        if (string.IsNullOrWhiteSpace(cpu))
            throw new ArgumentException("Потрібно зазначити процесор.", nameof(cpu));
        if (ramGb <= 0)
            throw new ArgumentOutOfRangeException(nameof(ramGb));

        Cpu = cpu.Trim();
        RamGb = ramGb;
    }

    public bool CanRunSoftware(int requiredRamGb, string cpuKeyword)
    {
        if (requiredRamGb <= 0)
            throw new ArgumentOutOfRangeException(nameof(requiredRamGb));
        if (string.IsNullOrWhiteSpace(cpuKeyword))
            throw new ArgumentException("Вкажіть частину назви процесора.", nameof(cpuKeyword));

        return RamGb >= requiredRamGb &&
            Cpu.Contains(cpuKeyword, StringComparison.OrdinalIgnoreCase);
    }

    public override string GetSpecifications() =>
        $"Ноутбук {Name}: процесор {Cpu}, RAM {RamGb} ГБ, ціна {Price:0.00} грн";
}
