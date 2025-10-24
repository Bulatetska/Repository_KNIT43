using lab14.Data;
using lab14.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace lab14.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Login(string? returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginPost(LoginViewModel viewModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == viewModel.Name && x.Password == viewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Name or Password");
                return View(viewModel);
            }
            await SignIn(HttpContext, user);

            return RedirectToLocal(viewModel.ReturnUrl);
        }

        public static async Task SignIn(HttpContext HttpContext, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
                new Claim(ClaimTypes.Name, user.Name),
            };
            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }

        public async Task<IActionResult> Logout(string? returnUrl)
        {
            await HttpContext.SignOutAsync();
            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string? returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> AccessDenied()
        {
            return Content("Нема доступу");
        }
    }
}
