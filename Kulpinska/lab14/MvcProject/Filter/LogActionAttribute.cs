using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcLab.Filters
{
    // Простіше логування в консоль перед та після виконання дії
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"[LOG] Before action: {context.ActionDescriptor.DisplayName}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[LOG] After action: {context.ActionDescriptor.DisplayName}");
        }
    }
}
