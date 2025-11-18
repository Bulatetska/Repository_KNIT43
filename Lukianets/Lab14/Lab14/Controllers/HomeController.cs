using Microsoft.AspNetCore.Mvc;

namespace MvcStoreLab.Controllers
{
    public class HomeController : Controller
    {
        // Головна сторінка
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            // Встановлюємо код статусу 403 (Forbidden) для коректності
            Response.StatusCode = 403;
            return View();
        }
    }
}