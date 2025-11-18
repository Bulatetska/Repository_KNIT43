using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcStoreLab.Filters
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        private readonly string _role;

        public AuthorizeUserAttribute(string role)
        {
            _role = role;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Тут має бути реальна логіка перевірки автентифікації/авторизації
            // У цьому прикладі ми просто перевіряємо, чи є користувач "адміном"
            bool isAuthenticated = true; // Припускаємо, що користувач автентифікований
            //bool isAuthenticated = false;
            string userRole = "Admin";   // Припускаємо, що роль користувача

            if (!isAuthenticated || userRole != _role)
            {
                // Перенаправлення на сторінку "Доступ заборонено"
                context.Result = new RedirectToActionResult("AccessDenied", "Home", null);
            }

            base.OnActionExecuting(context);
        }
    }
}