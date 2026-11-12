using HelloMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMvcApp.Controllers;

public class HelloController : Controller
{
    public IActionResult Index(string? format)
    {
        if (string.Equals(format, "text", StringComparison.OrdinalIgnoreCase))
        {
            return Content(
                "Вітаю! Це ваш перший контролер у ASP.NET Core MVC.",
                "text/plain; charset=utf-8");
        }

        var model = new GreetingModel
        {
            Title = "Привіт з подання!",
            Description = "Це ваше перше подання у ASP.NET Core MVC."
        };

        return View(model);
    }
}
