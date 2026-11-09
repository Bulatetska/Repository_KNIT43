using System.ComponentModel.DataAnnotations;

namespace Lab15_MvcStore.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public User? User { get; set; }

    public Product? Product { get; set; }
}