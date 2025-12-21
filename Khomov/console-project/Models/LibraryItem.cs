using ConsoleProject.Interfaces;

namespace ConsoleProject.Models;

public abstract class LibraryItem : IIdentifiable
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; }
    public int Year { get; }

    protected LibraryItem(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public override string ToString() => $"{Title} ({Year})";
}
