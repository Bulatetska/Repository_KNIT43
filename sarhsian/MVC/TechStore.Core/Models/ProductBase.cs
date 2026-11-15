using TechStore.Interfaces;

namespace TechStore.Models;

public abstract class ProductBase : ISellable
{
    public string Name { get; }
    public decimal Price { get; }

    protected ProductBase(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Назва не може бути порожньою.", nameof(name));
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Ціна не може бути від'ємною.");

        Name = name.Trim();
        Price = price;
    }

    public decimal GetDiscountPrice(int discountPercent)
    {
        if (discountPercent < 0 || discountPercent > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercent), "Знижка має бути від 0 до 100.");

        return decimal.Round(Price * (100 - discountPercent) / 100m, 2,
            MidpointRounding.AwayFromZero);
    }

    public abstract string GetSpecifications();
}
