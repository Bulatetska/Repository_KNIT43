using Microsoft.AspNetCore.Mvc;

namespace HelloMvcApp.Controllers
{
    public class HelloController : Controller
    {
        // Метод дії для маршруту /Hello/Index
        public IActionResult Index()
        {
            // Повертає подання Views/Hello/Index.cshtml
            return View();
        }
    }
}
