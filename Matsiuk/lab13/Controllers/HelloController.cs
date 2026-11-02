using Microsoft.AspNetCore.Mvc;

namespace HelloMvcApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}