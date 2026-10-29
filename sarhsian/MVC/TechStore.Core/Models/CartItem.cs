using TechStore.Interfaces;

namespace TechStore.Models;

public sealed class CartItem
{
    public ISellable Product { get; }
    public int Quantity { get; }

    public CartItem(ISellable product, int quantity)
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

        Quantity = quantity;
    }
}
