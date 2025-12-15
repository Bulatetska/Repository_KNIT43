using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = users.Count + 1;
                users.Add(user);
                return RedirectToAction("Details", new { id = user.Id });
            }
            return View(user);
        }

        public IActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Якщо користувача не знайдено, повертаємо на сторінку створення
                return RedirectToAction("Create");
            }
            
            return View(user);
        }

        // Додайте цей метод для списку користувачів
        public IActionResult Index()
        {
            return View(users);
        }
    }
}