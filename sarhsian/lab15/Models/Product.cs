using System.ComponentModel.DataAnnotations;

namespace Lab15MvcApp.Models;

public class Product
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    [Range(typeof(decimal), "0.01", "500000")]
    public decimal Price { get; set; }
    [Range(0, 1000)]
    public int Stock { get; set; }
}
