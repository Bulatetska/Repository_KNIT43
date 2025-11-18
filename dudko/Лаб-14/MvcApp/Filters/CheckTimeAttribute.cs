using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcApp.Filters
{
    public class CheckTimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (DateTime.Now.Hour < 9 || DateTime.Now.Hour > 21)
            {
                context.Result = new ContentResult()
                {
                    Content = "Сайт доступний лише з 9:00 до 21:00!"
                };
            }
        }
    }
}
