using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ProductApp.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        private readonly string _message;
        public LogActionAttribute(string message = null)
        {
            _message = message;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logger = (ILogger)context.HttpContext.RequestServices.GetService(typeof(ILogger<LogActionAttribute>));
            logger?.LogInformation("Executing action {action} {msg}", context.ActionDescriptor.DisplayName, _message);
            base.OnActionExecuting(context);
        }
    }
}
