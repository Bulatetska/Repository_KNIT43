using Microsoft.AspNetCore.Mvc;

namespace lab14.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult PlaceOrder()
        {
            return Content("Сторінка для розміщення замовлення");
        }
    }
}
