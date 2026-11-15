using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Services;

public sealed class ShoppingCart
{
    private readonly List<CartItem> _items = new();

    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

    public int AddItem(ISellable product, int quantity)
    {
        _items.Add(new CartItem(product, quantity));
        return _items.Count;
    }

    public int GetTotalQuantity() => _items.Sum(item => item.Quantity);
}
