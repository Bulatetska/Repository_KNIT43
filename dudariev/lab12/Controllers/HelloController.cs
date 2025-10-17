using Microsoft.AspNetCore.Mvc;

namespace lab12.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Вітаю! Це ваш перший контролер у ASP.NET Core MVC.");
            return View();
        }
    }
}
