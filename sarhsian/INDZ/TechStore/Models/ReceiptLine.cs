namespace TechStore.Models;

public sealed class ReceiptLine
{
    public string Name { get; }
    public int Quantity { get; }
    public decimal UnitPrice { get; }
    public decimal LineTotal => UnitPrice * Quantity;

    public ReceiptLine(string name, int quantity, decimal unitPrice)
    {
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
