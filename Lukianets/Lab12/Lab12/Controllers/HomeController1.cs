using Microsoft.AspNetCore.Mvc;

namespace Lab12.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    }
}

