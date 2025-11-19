using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EfSqliteDemo.Models;

class Program
{
    static void Main()
    {
        using var db = new ApplicationContext();

        db.Database.ExecuteSqlRaw("DELETE FROM Books");
        db.Database.ExecuteSqlRaw("DELETE FROM Authors");
        db.SaveChanges();

        // Створюємо авторів
        var author1 = new Author { FirstName = "Агата", LastName = "Крісті" };
        var author2 = new Author { FirstName = "Макс", LastName = "Кідрук" };

        db.Authors.Add(author1);
        db.Authors.Add(author2);

        // Створюємо книги і прив’язуємо до авторів
        var book1 = new Book { Title = "Пригоди різдвяного пудингу", Author = author1 };
        var book2 = new Book { Title = "Книга 1. Колонія", Author = author2 };
        var book3 = new Book { Title = "Книга 1. Колапс", Author = author2 };

        db.Books.AddRange(book1, book2, book3);

        // Зберігаємо зміни
        db.SaveChanges();

        Console.WriteLine("Дані збережено!\n");

        // Виводимо всі книги з авторами
        var books = db.Books.Include(b => b.Author).ToList();
        foreach (var b in books)
        {
            Console.WriteLine($"{b.Title} — {b.Author.FirstName} {b.Author.LastName}");
        }
    }
}
