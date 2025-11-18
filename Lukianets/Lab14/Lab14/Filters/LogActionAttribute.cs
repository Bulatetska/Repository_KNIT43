using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MvcStoreLab.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Власна логіка: логування початку виконання дії
            Debug.WriteLine($"[Custom Log] Початок виконання дії: {context.ActionDescriptor.DisplayName}");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Власна логіка: логування завершення виконання дії
            Debug.WriteLine($"[Custom Log] Завершення виконання дії: {context.ActionDescriptor.DisplayName}");
            base.OnActionExecuted(context);
        }
    }
}