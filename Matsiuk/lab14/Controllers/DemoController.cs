using Microsoft.AspNetCore.Mvc;

namespace RazorDemoApp.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Razor laboratory work!";

            return View();
        }

        public IActionResult List()
        {
            var countries = new List<string>
            {
                "Ukraine",
                "Poland",
                "Germany",
                "France"
            };

            return View(countries);
        }
    }
}
