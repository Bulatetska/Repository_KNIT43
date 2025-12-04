using Microsoft.AspNetCore.Mvc;

public class HelloController : Controller
{
    public IActionResult Index()
    {
        return Content("Вітаю! Це ваш перший контролер у ASP.NET Core MVC.");
    }
}
