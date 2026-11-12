namespace TechStore.Models;

public sealed class Receipt
{
    public IReadOnlyList<ReceiptLine> Lines { get; }
    public int DiscountPercent { get; }
    public decimal Total => Lines.Sum(line => line.LineTotal);

    public Receipt(IEnumerable<ReceiptLine> lines, int discountPercent)
    {
        Lines = lines.ToList().AsReadOnly();
        DiscountPercent = discountPercent;
    }
}
