using System.Security.Claims;
using Lab15MvcApp.Data;
using Lab15MvcApp.Models;
using Lab15MvcApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab15MvcApp.Controllers;

[Route("users")]
public class UserController(AppDbContext db, IPasswordHasher<AppUser> hasher) : Controller
{
    [AllowAnonymous]
    [HttpGet("create")]
    public IActionResult Create() => View(new RegisterModel());

    [AllowAnonymous]
    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RegisterModel input)
    {
        if (!ModelState.IsValid) return View(input);
        string email = input.Email.Trim().ToLowerInvariant();
        if (db.Users.Any(x => x.Email == email))
        {
            ModelState.AddModelError(nameof(input.Email), "Така електронна адреса вже існує.");
            return View(input);
        }

        var user = new AppUser { Name = input.Name.Trim(), Email = email, Role = "User" };
        user.PasswordHash = hasher.HashPassword(user, input.Password);
        db.Users.Add(user);
        db.SaveChanges();

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme)));
        return RedirectToAction(nameof(Details), new { id = user.Id });
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public IActionResult Details(int id)
    {
        if (!User.IsInRole("Admin") && User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
            return Forbid();
        var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        return user is null ? NotFound() : View(user);
    }
}
