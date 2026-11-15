using System.ComponentModel.DataAnnotations;

namespace Lab15MvcApp.ViewModels;

public class OrderFormModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Оберіть продукт.")]
    public int ProductId { get; set; }
    [Range(1, 100, ErrorMessage = "Кількість від 1 до 100.")]
    public int Quantity { get; set; } = 1;
}
