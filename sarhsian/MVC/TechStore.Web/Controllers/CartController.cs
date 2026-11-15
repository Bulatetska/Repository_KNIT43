using Microsoft.AspNetCore.Mvc;
using TechStore.Services;
using TechStore.Web.Models;
using TechStore.Web.Services;

namespace TechStore.Web.Controllers;

public sealed class CartController : Controller
{
    private readonly ProductCatalog _catalog;
    private readonly SessionCartStore _store;
    private readonly OrderProcessor _processor = new();

    public CartController(ProductCatalog catalog, SessionCartStore store)
    {
        _catalog = catalog;
        _store = store;
    }

    public IActionResult Index() => View(BuildModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(string productId, int quantity)
    {
        var product = _catalog.Find(productId);
        if (product is null || quantity < 1 || quantity > 99)
        {
            TempData["Error"] = "Виберіть товар та кількість від 1 до 99.";
            return RedirectToAction("Index", "Products");
        }

        var lines = _store.Load(HttpContext.Session);
        var existing = lines.FirstOrDefault(x => x.ProductId == product.Id);
        if (existing is null)
        {
            lines.Add(new CartLineData { ProductId = product.Id, Quantity = quantity });
        }
        else
        {
            if (existing.Quantity + quantity > 99)
            {
                TempData["Error"] = "Для одного товару дозволено не більше 99 одиниць.";
                return RedirectToAction("Index");
            }
            existing.Quantity += quantity;
        }

        _store.Save(HttpContext.Session, lines);
        _store.ClearReceipt(HttpContext.Session);
        TempData["Message"] = "Товар додано до кошика.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(string productId)
    {
        var lines = _store.Load(HttpContext.Session);
        lines.RemoveAll(x => x.ProductId == productId);
        _store.Save(HttpContext.Session, lines);
        _store.ClearReceipt(HttpContext.Session);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        _store.Save(HttpContext.Session, new List<CartLineData>());
        _store.ClearReceipt(HttpContext.Session);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SetDiscount(int discountPercent)
    {
        if (discountPercent < 0 || discountPercent > 100)
        {
            TempData["Error"] = "Знижка має бути від 0 до 100%.";
            return RedirectToAction("Index");
        }
        _store.SetDiscount(HttpContext.Session, discountPercent);
        _store.ClearReceipt(HttpContext.Session);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout()
    {
        var model = BuildModel();
        if (model.Items.Count == 0)
        {
            TempData["Error"] = "Кошик порожній.";
            return RedirectToAction("Index");
        }

        var coreCart = MakeCoreCart(_store.Load(HttpContext.Session));
        var receipt = _processor.Checkout(coreCart, model.DiscountPercent);
        var vm = new ReceiptViewModel
        {
            Lines = receipt.Lines.Select(line => new ReceiptLineViewModel
            {
                Name = line.Name,
                Quantity = line.Quantity,
                UnitPrice = line.UnitPrice
            }).ToList(),
            DiscountPercent = receipt.DiscountPercent,
            TotalQuantity = coreCart.GetTotalQuantity(),
            Total = receipt.Total
        };
        _store.SaveReceipt(HttpContext.Session, vm);
        return RedirectToAction(nameof(Receipt));
    }

    [HttpGet]
    public IActionResult Receipt()
    {
        var receipt = _store.GetReceipt(HttpContext.Session);
        return receipt is null ? RedirectToAction("Index") : View(receipt);
    }

    private CartViewModel BuildModel()
    {
        var stored = _store.Load(HttpContext.Session);
        var rows = stored.Select(line =>
        {
            var catalogItem = _catalog.Find(line.ProductId);
            if (catalogItem is null || line.Quantity <= 0) return null;
            return new CartItemViewModel
            {
                ProductId = catalogItem.Id,
                ProductName = catalogItem.Product.Name,
                Price = catalogItem.Product.Price,
                Quantity = line.Quantity
            };
        }).OfType<CartItemViewModel>().ToList();

        var discount = _store.GetDiscount(HttpContext.Session);
        var coreCart = MakeCoreCart(stored);
        return new CartViewModel
        {
            Items = rows,
            DiscountPercent = discount,
            Total = _processor.CalculateTotal(coreCart, discount)
        };
    }

    private ShoppingCart MakeCoreCart(IEnumerable<CartLineData> lines)
    {
        var cart = new ShoppingCart();
        foreach (var line in lines)
        {
            var product = _catalog.Find(line.ProductId);
            if (product is not null && line.Quantity > 0 && line.Quantity <= 99)
                cart.AddItem(product.Product, line.Quantity);
        }
        return cart;
    }
}
