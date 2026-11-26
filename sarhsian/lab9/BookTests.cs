using Lab5Classes.Models;
using NUnit.Framework;

namespace Lab9Tests;

[TestFixture, NonParallelizable]
public class BookTests
{
    [Test]
    public void Constructor_InitializesProperties()
    {
        var book = new Book("Кобзар", "Тарас Шевченко", 250m);
        Assert.That(book.Title, Is.EqualTo("Кобзар"));
        Assert.That(book.Author, Is.EqualTo("Тарас Шевченко"));
        Assert.That(book.Price, Is.EqualTo(250m));
    }

    [Test]
    public void Price_CanBeChanged()
    {
        var book = new Book("Кобзар", "Тарас Шевченко", 250m);
        book.Price = 300m;
        Assert.That(book.Price, Is.EqualTo(300m));
    }

    [Test]
    public void Price_Negative_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Book("Кобзар", "Тарас Шевченко", -1m));
    }

    [Test]
    public void Print_ShowsBookData()
    {
        var book = new Book("Кобзар", "Тарас Шевченко", 250m);
        string text = ConsoleOutput.Capture(book.Print);
        Assert.That(text, Does.Contain("Назва: Кобзар"));
        Assert.That(text, Does.Contain("Автор: Тарас Шевченко"));
        Assert.That(text, Does.Contain("Вартість:"));
        Assert.That(text, Does.Contain(250m.ToString("N2")));
    }

    [Test]
    public void BookGenre_Print_IncludesGenre()
    {
        Book book = new BookGenre("Лісова пісня", "Леся Українка", 180m, "драма-феєрія");
        string text = ConsoleOutput.Capture(book.Print);
        Assert.That(text, Does.Contain("Назва: Лісова пісня"));
        Assert.That(text, Does.Contain("Жанр: драма-феєрія"));
    }

    [Test]
    public void BookGenrePubl_Print_IncludesAllLevels()
    {
        Book book = new BookGenrePubl("Тіні забутих предків", "Михайло Коцюбинський", 210m, "повість", "Фоліо");
        string text = ConsoleOutput.Capture(book.Print);
        Assert.That(text, Does.Contain("Назва: Тіні забутих предків"));
        Assert.That(text, Does.Contain("Жанр: повість"));
        Assert.That(text, Does.Contain("Видавець: Фоліо"));
    }

    [Test]
    public void BookGenrePubl_IsSealed()
    {
        Assert.That(typeof(BookGenrePubl).IsSealed, Is.True);
    }
}
