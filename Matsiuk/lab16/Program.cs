using Microsoft.EntityFrameworkCore;
using Lab16_EFCore.Data;
using Lab16_EFCore.Models;

using var dbContext = new ApplicationContext();

// Add initial data
if (!dbContext.Authors.Any())
{
    var author1 = new Author
    {
        FirstName = "George",
        LastName = "Orwell"
    };

    var author2 = new Author
    {
        FirstName = "J.K.",
        LastName = "Rowling"
    };

    var books = new List<Book>
    {
        new Book
        {
            Title = "1984",
            Author = author1
        },
        new Book
        {
            Title = "Animal Farm",
            Author = author1
        },
        new Book
        {
            Title = "Harry Potter",
            Author = author2
        }
    };

    dbContext.AddRange(author1, author2);
    dbContext.AddRange(books);

    dbContext.SaveChanges();

    Console.WriteLine("Initial data has been added.");
}

// Display all books with their authors
Console.WriteLine("\n===== BOOK CATALOG =====\n");

var allBooks = dbContext.Books
    .Include(book => book.Author)
    .ToList();

foreach (var book in allBooks)
{
    Console.WriteLine($"Book ID: {book.Id}");
    Console.WriteLine($"Title: {book.Title}");
    Console.WriteLine(
        $"Author: {book.Author.FirstName} {book.Author.LastName}");

    Console.WriteLine("-------------------------");
}

Console.WriteLine("\nTotal books: " + allBooks.Count);