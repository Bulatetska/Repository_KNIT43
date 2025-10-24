using lab14.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace lab14
{
    public class SelfOrAdminAttribute : ActionFilterAttribute
    {
        public string UserIdParameter { get; set; } = "id";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.IsInRole("Admin"))
                return;

            object? value;
            if (!context.ActionArguments.TryGetValue(UserIdParameter, out value))
            {
                throw new InvalidOperationException($"SelfOrAdmin attribute did not find UserIdParameter {UserIdParameter}");
            }

            if (!(value is int id))
            {
                throw new InvalidOperationException($"UserIdParameter {UserIdParameter} is not an int");
            }

            int userId;
            if (!int.TryParse(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "", out userId))
            {
                context.Result = new UnauthorizedResult();
            }

            if (userId != id)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
