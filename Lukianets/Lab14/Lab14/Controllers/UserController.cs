using Microsoft.AspNetCore.Mvc;
using MvcStoreLab.Models;

namespace MvcStoreLab.Controllers
{
    public class UserController : Controller
    {
        // 1. Дія Create (GET - Відображення форми створення користувача)
        public IActionResult Create()
        {
            return View();
        }

        // 1. Дія Create (POST - Обробка даних форми)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Присвоєння нового Id (імітація DB)
                user.Id = DataStore.Users.Any() ? DataStore.Users.Max(u => u.Id) + 1 : 1;
                DataStore.Users.Add(user);
                // Перенаправляємо на сторінку деталей нового користувача
                return RedirectToAction(nameof(Details), new { id = user.Id });
            }
            return View(user);
        }

        // 2. Дія Details (Відображення даних користувача)
        public IActionResult Details(int id)
        {
            var user = DataStore.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            // Уникаємо відображення пароля на сторінці деталей
            user.Password = "********";
            return View(user);
        }
    }
}