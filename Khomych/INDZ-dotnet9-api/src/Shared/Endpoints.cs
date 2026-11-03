using Bench.Core;

namespace Bench.Api;

public static class Endpoints
{
    public static void MapBenchEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api");

        api.MapGet("/ping", () => TypedResults.Ok(new PingResponse("ok", "pong")));

        api.MapGet("/items", (ItemStore store, string? category, decimal? minPrice, bool? activeOnly) =>
            TypedResults.Ok(store.Filter(category, minPrice ?? 0, activeOnly ?? false)));

        api.MapGet("/items/{id:int}", IResult (ItemStore store, int id) =>
            store.Get(id) is { } item ? TypedResults.Ok(item) : TypedResults.NotFound());

        api.MapPost("/items", (ItemStore store, ItemInput input) =>
        {
            var item = store.Create(input);
            return TypedResults.Created($"/api/items/{item.Id}", item);
        });

        api.MapPut("/items/{id:int}", IResult (ItemStore store, int id, ItemInput input) =>
            store.Update(id, input) is { } item ? TypedResults.Ok(item) : TypedResults.NotFound());

        api.MapDelete("/items/{id:int}", IResult (ItemStore store, int id) =>
            store.Delete(id) ? TypedResults.NoContent() : TypedResults.NotFound());

        api.MapGet("/cpu", IResult (string? input, int? rounds) =>
        {
            var n = rounds ?? AppDefaults.DefaultRounds;
            if (n is < 1 or > AppDefaults.MaxRounds)
                return TypedResults.BadRequest(new ErrorResponse("rounds out of range"));
            return TypedResults.Ok(CpuWork.Run(input ?? AppDefaults.DefaultInput, n, DateTimeOffset.UtcNow));
        });
    }
}
