using Lab15_MvcStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab15_MvcStore.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var products = _db.Products
            .OrderBy(p => p.Name)
            .Take(4)
            .ToList();

        return View(products);
    }
}