using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RazorDemoApp.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Ласкаво просимо на лабораторну роботу з Razor!";
            return View();
        }

        public IActionResult List()
        {
            var countries = new List<string> { "Україна", "Польща", "Німеччина", "Франція" };
            return View(countries);
        }
    }
}