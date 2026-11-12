using System.Text;
using TechStore.Interfaces;
using TechStore.Models;
using TechStore.Services;

Console.InputEncoding = new UTF8Encoding(false);
Console.OutputEncoding = new UTF8Encoding(false);

var laptop = new Laptop("Acer Nitro V 15", 42000m, "Intel Core i5", 16);
var smartphone = new Smartphone("Samsung Galaxy A55", 17000m, 5000, "Android");

List<ISellable> products = new() { laptop, smartphone };

Console.WriteLine("TechStore - симулятор магазину техніки");
Console.WriteLine("Каталог товарів:");
foreach (ISellable product in products)
    Console.WriteLine(product.GetSpecifications());

Console.WriteLine();
Console.WriteLine($"Ноутбук підходить для ПЗ (RAM 8 ГБ, Intel): " +
    (laptop.CanRunSoftware(8, "Intel") ? "так" : "ні"));
Console.WriteLine($"Орієнтовна автономність смартфона: " +
    $"{smartphone.EstimateBatteryHours(500):0.0} год");

var cart = new ShoppingCart();
cart.AddItem(laptop, 1);
cart.AddItem(smartphone, 2);

var processor = new OrderProcessor();
const int discountPercent = 10;
Receipt receipt = processor.Checkout(cart, discountPercent);

Console.WriteLine();
Console.WriteLine("Чек замовлення:");
foreach (ReceiptLine line in receipt.Lines)
    Console.WriteLine($"{line.Name}: {line.Quantity} x {line.UnitPrice:0.00} = {line.LineTotal:0.00} грн");

Console.WriteLine($"Знижка: {receipt.DiscountPercent}%");
Console.WriteLine($"Кількість одиниць: {cart.GetTotalQuantity()}");
Console.WriteLine($"До сплати: {processor.CalculateTotal(cart, discountPercent):0.00} грн");
