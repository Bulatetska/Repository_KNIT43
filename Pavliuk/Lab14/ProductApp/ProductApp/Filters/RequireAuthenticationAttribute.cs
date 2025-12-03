using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductApp.Filters
{
    public class RequireAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("user");

            if (string.IsNullOrEmpty(user))
            {
                // Користувач не авторизований → редірект на створення акаунта
                context.Result = new RedirectToActionResult("Create", "User", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
