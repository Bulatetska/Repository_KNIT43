namespace TechStore.Web.Models;

public sealed class ReceiptViewModel
{
    public List<ReceiptLineViewModel> Lines { get; set; } = new();
    public int DiscountPercent { get; set; }
    public int TotalQuantity { get; set; }
    public decimal Total { get; set; }
}
