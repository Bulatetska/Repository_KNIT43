using lab15;
using lab15.Models;
using Microsoft.EntityFrameworkCore;

using var db = new ApplicationContext();

var author1 = new Author { FirstName = "Джордж", LastName = "Орвел" };
var author2 = new Author { FirstName = "Кен", LastName = "Бруен" };

db.Authors.AddRange(author1, author2);
db.SaveChanges();

var book1 = new Book { Title = "1984", AuthorId = author1.Id };
var book2 = new Book { Title = "Колгосп Тварин", AuthorId = author1.Id };
var book3 = new Book { Title = "Драматург", AuthorId = author2.Id };

db.Books.AddRange(book1, book2, book3);
db.SaveChanges();

var booksWithAuthors = db.Books.Include(b => b.Author).ToList();

foreach (var book in booksWithAuthors)
{
    Console.WriteLine($"Книга: {book.Title}, Автор: {book.Author.FirstName} {book.Author.LastName}");
}
