using Microsoft.AspNetCore.Mvc;

namespace RazorDemoApp.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            // Передача даних у подання через ViewData
            ViewData["Message"] = "Ласкаво просимо на лабораторну роботу з Razor!";
            return View();
        }

        public IActionResult List()
        {
            // Передача моделі (списку рядків) у подання
            var countries = new List<string> { "Україна", "Польща", "Німеччина", "Франція" };
            return View(countries);
        }
    }
}
