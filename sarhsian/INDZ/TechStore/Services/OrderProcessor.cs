using TechStore.Models;

namespace TechStore.Services;
public sealed class OrderProcessor
{
    public decimal CalculateTotal(ShoppingCart cart, int discountPercent)
    {
        return Checkout(cart, discountPercent).Total;
    }

    public Receipt Checkout(ShoppingCart cart, int discountPercent)
    {
        ArgumentNullException.ThrowIfNull(cart);
        if (discountPercent < 0 || discountPercent > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercent));

        var lines = cart.Items.Select(item => new ReceiptLine(
            item.Product.Name,
            item.Quantity,
            item.Product.GetDiscountPrice(discountPercent)));

        return new Receipt(lines, discountPercent);
    }
}
