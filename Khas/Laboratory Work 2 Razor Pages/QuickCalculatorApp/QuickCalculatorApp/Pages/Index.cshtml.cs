using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuickCalculatorApp.Pages
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    public class IndexModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public decimal FinalPrice { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(double discount)
        {
            FinalPrice = Product.Price - (Product.Price * (decimal)discount / 100);
            Message = $"Товар: {Product.Name}, категорія: {Product.Category}. " +
                       $"Ціна: {Product.Price} грн, знижка: {discount}%, " +
                       $"підсумкова ціна: {FinalPrice:F2} грн";
        }
    }
}
