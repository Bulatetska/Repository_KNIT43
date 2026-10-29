using HelloEfApp.Data;
using HelloEfApp.Models;
using Microsoft.EntityFrameworkCore;

using var db = new ApplicationContext();

Console.WriteLine($"База даних: {ApplicationContext.DatabasePath}");

// Таблиці потрібно створювати через міграції Entity Framework Core.
if (!db.Database.GetMigrations().Any())
{
    Console.WriteLine("Міграцію не знайдено.");
    Console.WriteLine("Виконайте Add-Migration InitialCreate у Package Manager Console, потім Update-Database.");
    return;
}

// Застосовує незастосовані міграції до тієї самої бази даних.
db.Database.Migrate();

if (!db.Authors.Any())
{
    var author1 = new Author { FirstName = "Тарас", LastName = "Шевченко" };
    var author2 = new Author { FirstName = "Леся", LastName = "Українка" };

    db.Add(author1);
    db.Add(author2);
    db.Add(new Book { Title = "Кобзар", Author = author1 });
    db.Add(new Book { Title = "Гайдамаки", Author = author1 });
    db.Add(new Book { Title = "Лісова пісня", Author = author2 });

    db.SaveChanges();
    Console.WriteLine("Початкові дані додано.");
}

Console.WriteLine("Список книг:");
var books = db.Books
    .Include(b => b.Author)
    .OrderBy(b => b.Title)
    .ToList();

foreach (var book in books)
{
    Console.WriteLine($"{book.Id}. {book.Title} - {book.Author.LastName} {book.Author.FirstName}");
}
