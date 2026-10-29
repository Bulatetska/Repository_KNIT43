namespace TechStore.Web.Models;

public sealed class ReceiptLineViewModel
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total => UnitPrice * Quantity;
}
