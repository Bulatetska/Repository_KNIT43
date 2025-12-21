using Microsoft.AspNetCore.Mvc;
using lab14.Models;
using System.Collections.Generic;
using System.Linq;

namespace lab14.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();

        // Список користувачів
        public IActionResult List()
        {
            return View(users);
        }

        // Створити користувача
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return RedirectToAction("List");
        }
    }
}
