using Microsoft.EntityFrameworkCore;

using var db = new ApplicationContext();

var author1 = new Author { LastName = "Гончар", FirstName = "Степан" };
var author2 = new Author { LastName = "Калина", FirstName = "Іван" };
db.Add(author1);
db.Add(author2);

db.Add(new Book { Title = "Книга 1", Author = author1 });
db.Add(new Book { Title = "Книга 2", Author = author1 });
db.Add(new Book { Title = "Книга 3", Author = author2 });

db.SaveChanges();

var books =
    from book in db.Books.Include(book => book.Author)
    select book;

foreach (var book in books)
{
    Console.WriteLine("Книга \"{0}\" ({3}) автора \"{1} {2}\" ({4})", book.Title, book.Author.FirstName, book.Author.LastName, book.Id, book.Author.Id);
}