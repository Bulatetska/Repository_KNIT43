using TechStore.Interfaces;

namespace TechStore.Web.Models;

public sealed record CatalogItem(
    string Id,
    string Category,
    string Details,
    ISellable Product);
