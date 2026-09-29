using TaskManager.Models;

namespace TaskManager.Data;

public static class FakeDatabase
{
    public static List<Category> Categories { get; set; } = new List<Category>
    {
        new Category { Id = 1, Name = "Робота" },
        new Category { Id = 2, Name = "Навчання" }
    };
}
