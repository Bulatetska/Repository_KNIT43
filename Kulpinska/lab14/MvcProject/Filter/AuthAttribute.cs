using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcLab.Filters
{
    // Простий фільтр авторизації: пускає лише якщо IsAdmin = "true" у сесії
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var isAdmin = httpContext.Session.GetString("IsAdmin");

            if (isAdmin != "true")
            {
                // Якщо не адмін – перенаправляємо на сторінку логіну
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
