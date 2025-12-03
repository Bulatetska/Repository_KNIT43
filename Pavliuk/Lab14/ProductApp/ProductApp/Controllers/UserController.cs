//UserController.cs
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
namespace ProductApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();
        private static int nextId = 1;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Create(User user)
        {
            user.Id = nextId++;
            users.Add(user);
            HttpContext.Session.SetString("user", user.Name);
            HttpContext.Session.SetString("role", user.Role ?? "User");
            return RedirectToAction(nameof(Details), new {id = user.Id});
        }
        public IActionResult Details(int id)
        {
            var u = users.SingleOrDefault(x => x.Id == id);
             
            return View(u);
        }
    }
}
