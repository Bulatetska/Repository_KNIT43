using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuickCalculatorApp.Pages
{
    public class QuickCalculator : PageModel
    {
        public string Message { get; set; }

    public void OnGet(decimal price, double discount)
        {
            decimal finalPrice = price - (price * (decimal)discount / 100);
            Message = $"Початкова ціна: {price} грн, знижка: {discount}%, " + $"підсумкова ціна: {finalPrice:F2} грн";
        }
    }
}
