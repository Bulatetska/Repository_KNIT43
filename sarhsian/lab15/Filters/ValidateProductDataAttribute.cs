using Lab15MvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab15MvcApp.Filters;

// Власний фільтр дії: додаткова бізнес-перевірка до запуску дії.
[AttributeUsage(AttributeTargets.Method)]
public sealed class ValidateProductDataAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.TryGetValue("input", out var argument)
            && argument is ProductFormModel product)
        {
            if (product.Name?.Contains('#') == true)
                context.ModelState.AddModelError(nameof(product.Name),
                    "Назва товару не повинна містити символ #.");
            if (product.Price > 100000m)
                context.ModelState.AddModelError(nameof(product.Price),
                    "У навчальному каталозі ціна не може перевищувати 100 000 грн.");
        }
        base.OnActionExecuting(context);
    }
}
