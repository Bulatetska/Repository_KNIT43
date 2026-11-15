using System.Security.Claims;
using Lab15MvcApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab15MvcApp.Controllers;

[Authorize(Roles = "Admin")]
[Route("admin")]
public class AdminController(AppDbContext db) : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View();

    [HttpGet("users")]
    public IActionResult Users() => View(db.Users.AsNoTracking().OrderBy(x => x.Id).ToList());

    [HttpGet("products")]
    public IActionResult Products() => View(db.Products.AsNoTracking().OrderBy(x => x.Id).ToList());

    [HttpPost("users/{id:int}/delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteUser(int id)
    {
        var user = db.Users.Find(id);
        if (user is null) return NotFound();
        if (user.Role == "Admin" || User.FindFirstValue(ClaimTypes.NameIdentifier) == id.ToString())
        {
            TempData["Error"] = "Адміністратора видаляти заборонено.";
            return RedirectToAction(nameof(Users));
        }
        if (db.Orders.Any(o => o.UserId == id))
        {
            TempData["Error"] = "У користувача вже є замовлення. Видалення заборонено.";
            return RedirectToAction(nameof(Users));
        }
        db.Users.Remove(user);
        db.SaveChanges();
        TempData["Message"] = "Користувача видалено.";
        return RedirectToAction(nameof(Users));
    }
}
