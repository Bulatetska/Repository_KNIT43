namespace TechStore.Web.Models;

public sealed class CartItemViewModel
{
    public string ProductId { get; init; } = string.Empty;
    public string ProductName { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public decimal LineTotal => Price * Quantity;
}
