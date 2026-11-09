using System.Security.Claims;
using Lab15_MvcStore.Data;
using Lab15_MvcStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab15_MvcStore.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IPasswordHasher<User> _hasher;

    public UserController(
        ApplicationDbContext db,
        IPasswordHasher<User> hasher)
    {
        _db = db;
        _hasher = hasher;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        string fullName,
        string email,
        string password)
    {
        if (string.IsNullOrWhiteSpace(fullName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            ModelState.AddModelError("", "All fields are required.");
            return View();
        }

        if (password.Length < 8)
        {
            ModelState.AddModelError(
                "",
                "Password must contain at least 8 characters.");

            return View();
        }

        if (await _db.Users.AnyAsync(u => u.Email == email))
        {
            ModelState.AddModelError(
                "",
                "An account with this email already exists.");

            return View();
        }

        var user = new User
        {
            FullName = fullName.Trim(),
            Email = email.Trim().ToLowerInvariant(),
            Role = "User"
        };

        user.PasswordHash = _hasher.HashPassword(user, password);

        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        TempData["Success"] = "Account created successfully.";

        return RedirectToAction("Login", "Account");
    }

    [Authorize]
    public async Task<IActionResult> Details(int id)
    {
        var currentUserId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        bool isAdmin = User.IsInRole("Admin");

        if (!isAdmin && currentUserId != id.ToString())
            return Forbid();

        var user = await _db.Users.FindAsync(id);

        if (user == null)
            return NotFound();

        return View(user);
    }
}