using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EfCoreLab.Models;

namespace EfCoreLab
{
    class Program
    {
        static void Main()
        {
            using var db = new ApplicationContext();

            db.Database.Migrate();

            if (!db.Authors.Any())
            {
                var author1 = new Author { FirstName = "Іван", LastName = "Франко" };
                var author2 = new Author { FirstName = "Леся", LastName = "Українка" };

                db.Authors.AddRange(author1, author2);
                db.SaveChanges();

                var book1 = new Book { Title = "Захар Беркут", Author = author1 };
                var book2 = new Book { Title = "Каменярі", Author = author1 };
                var book3 = new Book { Title = "Лісова пісня", Author = author2 };

                db.Books.AddRange(book1, book2, book3);
                db.SaveChanges();
            }

            var books = db.Books.Include(b => b.Author).ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Книга: {book.Title}, Автор: {book.Author.FirstName} {book.Author.LastName}");
            }
        }
    }
}
