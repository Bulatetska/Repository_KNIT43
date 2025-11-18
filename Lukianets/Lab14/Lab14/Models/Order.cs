namespace MvcStoreLab.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Username { get; set; } // Для прикладу, хто зробив замовлення
        public string ProductNames { get; set; } // Для прикладу, список продуктів
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}