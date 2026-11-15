using System.ComponentModel.DataAnnotations;

namespace Lab15MvcApp.ViewModels;

public class ProductFormModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Введіть назву товару.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Назва має містити 3–100 символів.")]
    public string Name { get; set; } = "";
    [StringLength(500)]
    public string Description { get; set; } = "";
    [Range(typeof(decimal), "0.01", "500000", ErrorMessage = "Ціна має бути від 0,01 до 500 000.")]
    public decimal Price { get; set; }
    [Range(0, 1000, ErrorMessage = "Кількість має бути від 0 до 1000.")]
    public int Stock { get; set; }
}
