using NUnit.Framework;
using MyApp;
using System;

namespace BookTests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Book_SettersAndGetters_WorkCorrectly()
        {
            var book = new Book("War and Peace", "Leo Tolstoy", 150.0);

            Assert.That(book.Title, Is.EqualTo("War and Peace"));
            Assert.That(book.Author, Is.EqualTo("Leo Tolstoy"));
            Assert.That(book.Price, Is.EqualTo(150.0));

            book.Title = "Anna Karenina";
            book.Author = "Leo Tolstoy";
            book.Price = 120.0;

            Assert.That(book.Title, Is.EqualTo("Anna Karenina"));
            Assert.That(book.Author, Is.EqualTo("Leo Tolstoy"));
            Assert.That(book.Price, Is.EqualTo(120.0));
        }

        [Test]
        public void Book_Print_DoesNotThrow()
        {
            var book = new Book("War and Peace", "Leo Tolstoy", 150.0);
            Assert.DoesNotThrow(() => book.Print());
        }
    }

    [TestFixture]
    public class BookGenreTests
    {
        [Test]
        public void BookGenre_SettersAndGetters_WorkCorrectly()
        {
            var genreBook = new BookGenre("1984", "George Orwell", 200.0, "Dystopia");

            Assert.That(genreBook.Title, Is.EqualTo("1984"));
            Assert.That(genreBook.Author, Is.EqualTo("George Orwell"));
            Assert.That(genreBook.Price, Is.EqualTo(200.0));
            Assert.That(genreBook.Genre, Is.EqualTo("Dystopia"));

            genreBook.Title = "Animal Farm";
            genreBook.Author = "George Orwell";
            genreBook.Price = 180.0;
            genreBook.Genre = "Political satire";

            Assert.That(genreBook.Title, Is.EqualTo("Animal Farm"));
            Assert.That(genreBook.Author, Is.EqualTo("George Orwell"));
            Assert.That(genreBook.Price, Is.EqualTo(180.0));
            Assert.That(genreBook.Genre, Is.EqualTo("Political satire"));
        }

        [Test]
        public void BookGenre_Print_DoesNotThrow()
        {
            var genreBook = new BookGenre("1984", "George Orwell", 200.0, "Dystopia");
            Assert.DoesNotThrow(() => genreBook.Print());
        }
    }

    [TestFixture]
    public class BookGenrePublTests
    {
        [Test]
        public void BookGenrePubl_SettersAndGetters_WorkCorrectly()
        {
            var publBook = new BookGenrePubl("The Hobbit", "J.R.R. Tolkien", 300.0, "Fantasy", "Allen & Unwin");

            Assert.That(publBook.Title, Is.EqualTo("The Hobbit"));
            Assert.That(publBook.Author, Is.EqualTo("J.R.R. Tolkien"));
            Assert.That(publBook.Price, Is.EqualTo(300.0));
            Assert.That(publBook.Genre, Is.EqualTo("Fantasy"));
            Assert.That(publBook.Publisher, Is.EqualTo("Allen & Unwin"));

            publBook.Title = "The Lord of the Rings";
            publBook.Author = "J.R.R. Tolkien";
            publBook.Price = 500.0;
            publBook.Genre = "Fantasy";
            publBook.Publisher = "HarperCollins";

            Assert.That(publBook.Title, Is.EqualTo("The Lord of the Rings"));
            Assert.That(publBook.Author, Is.EqualTo("J.R.R. Tolkien"));
            Assert.That(publBook.Price, Is.EqualTo(500.0));
            Assert.That(publBook.Genre, Is.EqualTo("Fantasy"));
            Assert.That(publBook.Publisher, Is.EqualTo("HarperCollins"));
        }

        [Test]
        public void BookGenrePubl_Print_DoesNotThrow()
        {
            var publBook = new BookGenrePubl("The Hobbit", "J.R.R. Tolkien", 300.0, "Fantasy", "Allen & Unwin");
            Assert.DoesNotThrow(() => publBook.Print());
        }
    }
}