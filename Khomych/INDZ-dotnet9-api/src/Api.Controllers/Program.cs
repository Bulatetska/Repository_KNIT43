using Bench.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Services.AddSingleton<ItemStore>();
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(o => o.SuppressMapClientErrors = true) // 404 без ProblemDetails, як у Minimal API
    .AddJsonOptions(o => o.JsonSerializerOptions.TypeInfoResolverChain.Insert(0, BenchJsonContext.Default));

var app = builder.Build();
app.Services.GetRequiredService<ItemStore>(); // дані готуються до першого запиту в усіх варіантах
app.MapControllers();
app.Run();
