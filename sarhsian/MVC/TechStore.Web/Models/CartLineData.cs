namespace TechStore.Web.Models;

public sealed class CartLineData
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
