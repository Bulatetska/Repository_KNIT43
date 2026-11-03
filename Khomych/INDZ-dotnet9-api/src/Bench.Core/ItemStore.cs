using System.Collections.Concurrent;

namespace Bench.Core;

/// <summary>Сховище в пам'яті на 10 000 об'єктів. Дані детерміновані (фіксований seed).</summary>
public sealed class ItemStore
{
    public const int SeedCount = 10_000;
    private static readonly string[] Categories = ["electronics", "books", "garden", "toys"];
    private static readonly string[] TagPool = ["new", "sale", "popular", "eco", "premium", "limited"];

    private readonly ConcurrentDictionary<int, Item> _items = new();
    private int _nextId = SeedCount;

    public ItemStore()
    {
        var rnd = new Random(42);
        var epoch = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        for (var i = 1; i <= SeedCount; i++)
        {
            _items[i] = new Item(
                Id: i,
                Name: $"Item {i:D5}",
                Category: Categories[rnd.Next(Categories.Length)],
                Price: Math.Round((decimal)(rnd.NextDouble() * 200), 2),
                Stock: rnd.Next(0, 1000),
                Active: rnd.Next(100) < 80,
                CreatedUtc: epoch.AddMinutes(rnd.Next(0, 500_000)),
                Tags: [TagPool[rnd.Next(TagPool.Length)], TagPool[rnd.Next(TagPool.Length)]]);
        }
    }

    public int Count => _items.Count;

    public FilterResponse Filter(string? category, decimal minPrice, bool activeOnly)
    {
        var result = new List<Item>(2048);
        var scanned = 0;
        foreach (var (_, item) in _items)
        {
            scanned++;
            if (item.Price < minPrice) continue;
            if (activeOnly && !item.Active) continue;
            if (category is not null && !string.Equals(item.Category, category, StringComparison.Ordinal)) continue;
            result.Add(item);
        }
        return new FilterResponse(scanned, result.Count, result);
    }

    public Item? Get(int id) => _items.GetValueOrDefault(id);

    public Item Create(ItemInput input)
    {
        var id = Interlocked.Increment(ref _nextId);
        var item = ToItem(id, input, DateTime.UtcNow);
        _items[id] = item;
        return item;
    }

    public Item? Update(int id, ItemInput input)
    {
        if (!_items.TryGetValue(id, out var existing)) return null;
        var item = ToItem(id, input, existing.CreatedUtc);
        _items[id] = item;
        return item;
    }

    public bool Delete(int id) => _items.TryRemove(id, out _);

    private static Item ToItem(int id, ItemInput i, DateTime created) =>
        new(id, i.Name, i.Category, i.Price, i.Stock, i.Active, created, i.Tags);
}
