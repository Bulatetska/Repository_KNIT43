namespace TechStore.Web.Models;

public sealed class CartViewModel
{
    public List<CartItemViewModel> Items { get; init; } = new();
    public int DiscountPercent { get; init; }
    public decimal Total { get; init; }
    public decimal Subtotal => Items.Sum(item => item.LineTotal);
    public int TotalQuantity => Items.Sum(item => item.Quantity);
}
