﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using (var db = new ApplicationContext())
        {
            // Якщо база порожня — додаємо дані
            if (!db.Authors.Any())
            {
                var author1 = new Author { FirstName = "George", LastName = "Orwell" };
                var author2 = new Author { FirstName = "Jane", LastName = "Austen" };

                var book1 = new Book { Title = "1984", Author = author1 };
                var book2 = new Book { Title = "Animal Farm", Author = author1 };
                var book3 = new Book { Title = "Pride and Prejudice", Author = author2 };

                db.Authors.AddRange(author1, author2);
                db.Books.AddRange(book1, book2, book3);
                db.SaveChanges();
                Console.WriteLine("Вітаємо!Початкові дані додано!");
            }

            Console.WriteLine("\n Список книг з авторами:\n");

            var books = db.Books.Include(b => b.Author).ToList();

            foreach (var b in books)
            {
                Console.WriteLine($"{b.Title} — {b.Author.FirstName} {b.Author.LastName}");
            }
        }
    }
}
