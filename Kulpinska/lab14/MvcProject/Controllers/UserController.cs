using Microsoft.AspNetCore.Mvc;
using MvcLab.Models;

namespace MvcLab.Controllers
{
    public class UserController : Controller
    {
        public static List<AppUser> Users = new();

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(AppUser user)
        {
            user.Id = Users.Count == 0 ? 1 : Users.Max(u => u.Id) + 1;
            Users.Add(user);
            return RedirectToAction("Details", new { id = user.Id });
        }

        public IActionResult Details(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

        public IActionResult List()
        {
            return View(Users);
        }
    }
}
