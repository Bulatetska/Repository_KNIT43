using Microsoft.AspNetCore.Mvc;

namespace Lab15MvcApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    [Route("Home/Error")]
    public IActionResult Error() => View();
}
