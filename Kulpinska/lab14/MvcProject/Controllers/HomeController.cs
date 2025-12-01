using Microsoft.AspNetCore.Mvc;

namespace MvcLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Форма логіну
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Дуже проста авторизація: admin / 123
            if (username == "admin" && password == "123")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Dashboard", "Admin");
            }

            ViewBag.Error = "Невірний логін або пароль";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Index");
        }
    }
}
