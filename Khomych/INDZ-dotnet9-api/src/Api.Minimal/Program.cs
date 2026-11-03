using Bench.Core;
using Bench.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Services.AddSingleton<ItemStore>();
builder.Services.ConfigureHttpJsonOptions(o =>
    o.SerializerOptions.TypeInfoResolverChain.Insert(0, BenchJsonContext.Default));

var app = builder.Build();
app.Services.GetRequiredService<ItemStore>();
app.MapBenchEndpoints();
app.Run();
