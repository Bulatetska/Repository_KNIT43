using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProductApp.Filters
{
    public class RequireRoleAttribute : Attribute, IActionFilter
    {
        private readonly string _role;
        public RequireRoleAttribute(string role) => _role = role;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var role = context.HttpContext.Session.GetString("role");
            if (role != _role)
            {
                context.Result = new ContentResult
                {
                    Content = "Access denied: insufficient permissions",
                    StatusCode = 403
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
