using Lab15_MvcStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab15_MvcStore.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _db;

    public AdminController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.ProductsCount = await _db.Products.CountAsync();
        ViewBag.UsersCount = await _db.Users.CountAsync();
        ViewBag.OrdersCount = await _db.Orders.CountAsync();

        return View();
    }

    public async Task<IActionResult> Products()
    {
        var products = await _db.Products
            .OrderBy(p => p.Name)
            .ToListAsync();

        return View(products);
    }

    public async Task<IActionResult> Users()
    {
        var users = await _db.Users
            .OrderBy(u => u.FullName)
            .ToListAsync();

        return View(users);
    }
}