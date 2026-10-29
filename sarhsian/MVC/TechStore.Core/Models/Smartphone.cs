namespace TechStore.Models;

public sealed class Smartphone : ProductBase
{
    public int BatteryCapacityMah { get; }
    public string OperatingSystem { get; }

    public Smartphone(string name, decimal price, int batteryCapacityMah, string operatingSystem)
        : base(name, price)
    {
        if (batteryCapacityMah <= 0)
            throw new ArgumentOutOfRangeException(nameof(batteryCapacityMah));
        if (string.IsNullOrWhiteSpace(operatingSystem))
            throw new ArgumentException("Потрібно зазначити ОС.", nameof(operatingSystem));

        BatteryCapacityMah = batteryCapacityMah;
        OperatingSystem = operatingSystem.Trim();
    }

    public double EstimateBatteryHours(int consumptionMilliAmps)
    {
        if (consumptionMilliAmps <= 0)
            throw new ArgumentOutOfRangeException(nameof(consumptionMilliAmps));

        return (double)BatteryCapacityMah / consumptionMilliAmps;
    }

    public override string GetSpecifications() =>
        $"Смартфон {Name}: акумулятор {BatteryCapacityMah} мА·год, ОС {OperatingSystem}, ціна {Price:0.00} грн";
}
