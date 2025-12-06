using EfCoreLab;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var db = new ApplicationContext();
        if (!db.Authors.Any())
        {
            var author1 = new Author { FirstName = "Phil", LastName = "Stamper" };
            var author2 = new Author { FirstName = "Tess", LastName = "Gerritson" };

            db.Authors.AddRange(author1, author2);
            db.SaveChanges(); 

            var book1 = new Book { Title = "Golden boys", Author = author1 };
            var book2 = new Book { Title = "Surgen", Author = author1 };
            var book3 = new Book { Title = "Silent Girl", Author = author2 };

            db.Books.AddRange(book1, book2, book3);
            db.SaveChanges();
        }

        Console.WriteLine($"Authors count: {db.Authors.Count()}");
        Console.WriteLine($"Books count: {db.Books.Count()}\n");

        var books = db.Books.Include(b => b.Author).ToList();

        Console.WriteLine("Books in database:\n");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Title} — {book.Author.FirstName} {book.Author.LastName}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
