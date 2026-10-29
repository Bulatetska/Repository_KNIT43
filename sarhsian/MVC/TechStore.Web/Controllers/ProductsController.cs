using Microsoft.AspNetCore.Mvc;
using TechStore.Web.Services;

namespace TechStore.Web.Controllers;

public sealed class ProductsController : Controller
{
    private readonly ProductCatalog _catalog;

    public ProductsController(ProductCatalog catalog)
    {
        _catalog = catalog;
    }

    public IActionResult Index() => View(_catalog.Items);
}
