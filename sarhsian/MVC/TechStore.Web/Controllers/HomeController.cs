using Microsoft.AspNetCore.Mvc;

namespace TechStore.Web.Controllers;

public sealed class HomeController : Controller
{
    public IActionResult Error() => View();
}
