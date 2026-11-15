using System.Security.Claims;
using Lab15MvcApp.Data;
using Lab15MvcApp.Models;
using Lab15MvcApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab15MvcApp.Controllers;

[Route("account")]
public class AccountController(AppDbContext db, IPasswordHasher<AppUser> hasher) : Controller
{
    [AllowAnonymous]
    [HttpGet("login")]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View(new LoginModel());
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel input, string? returnUrl = null)
    {
        if (!ModelState.IsValid) return View(input);

        var email = input.Email.Trim().ToLowerInvariant();
        var user = db.Users.FirstOrDefault(x => x.Email == email);
        if (user is null || hasher.VerifyHashedPassword(user, user.PasswordHash, input.Password)
            == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("", "Невірна електронна адреса або пароль.");
            return View(input);
        }

        await SignInUserAsync(user);
        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            return LocalRedirect(returnUrl);
        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    [HttpPost("logout")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    [HttpGet("denied")]
    public IActionResult Denied() => View();

    public async Task SignInUserAsync(AppUser user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));
    }
}
