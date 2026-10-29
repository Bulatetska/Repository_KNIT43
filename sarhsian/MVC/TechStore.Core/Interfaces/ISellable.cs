namespace TechStore.Interfaces;

public interface ISellable
{
    string Name { get; }
    decimal Price { get; }
    decimal GetDiscountPrice(int discountPercent);
    string GetSpecifications();
}
