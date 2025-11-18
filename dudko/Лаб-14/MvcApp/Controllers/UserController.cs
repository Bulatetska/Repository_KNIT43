using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> Users { get; set; } = new List<User>();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(Users);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
            return RedirectToAction("Index", "Admin");
        }

        public static List<User> GetUsers()
        {
            return Users;
        }
        
    }
}
