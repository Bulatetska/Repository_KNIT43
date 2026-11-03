using System.Text.Json.Serialization;

namespace Bench.Core;

public sealed record PingResponse(string Status, string Message);

public sealed record Item(
    int Id,
    string Name,
    string Category,
    decimal Price,
    int Stock,
    bool Active,
    DateTime CreatedUtc,
    string[] Tags);

public sealed record ItemInput(
    string Name,
    string Category,
    decimal Price,
    int Stock,
    bool Active,
    string[] Tags);

public sealed record FilterResponse(int Scanned, int Matched, IReadOnlyList<Item> Items);

public sealed record CpuResponse(string Hash, int Rounds, string Token);

public sealed record ErrorResponse(string Error);

/// <summary>Один і той самий source-generated контекст для всіх трьох варіантів.</summary>
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    DefaultIgnoreCondition = JsonIgnoreCondition.Never)]
[JsonSerializable(typeof(PingResponse))]
[JsonSerializable(typeof(Item))]
[JsonSerializable(typeof(ItemInput))]
[JsonSerializable(typeof(FilterResponse))]
[JsonSerializable(typeof(CpuResponse))]
[JsonSerializable(typeof(ErrorResponse))]
public sealed partial class BenchJsonContext : JsonSerializerContext;
