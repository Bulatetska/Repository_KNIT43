using Microsoft.AspNetCore.Mvc;

namespace HelloMvcApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Welcome(string name = "Гість")
        {
            ViewData["Name"] = name;
            return View();
        }
    }
}