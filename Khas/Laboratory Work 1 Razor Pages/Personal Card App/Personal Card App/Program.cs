var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); // Сервіси Razor Pages

var app = builder.Build();
app.MapRazorPages(); // Маршрутизація Razor Pages

app.Run();