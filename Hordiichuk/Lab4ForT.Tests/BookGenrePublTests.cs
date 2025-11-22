// Lab4ForT.Tests/BookGenrePublTests.cs
using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class BookGenrePublTests
    {
        [Test]
        public void Constructor_ValidArguments_CreatesBookGenrePubl()
        {
            var book = new BookGenrePubl("C# in Depth", "Jon Skeet", 100, "Programming", "Manning");

            Assert.That(book.Title, Is.EqualTo("C# in Depth"));
            Assert.That(book.Author, Is.EqualTo("Jon Skeet"));
            Assert.That(book.Price, Is.EqualTo(100));
            Assert.That(book.Genre, Is.EqualTo("Programming"));
            Assert.That(book.Publisher, Is.EqualTo("Manning"));
        }

        [Test]
        public void Constructor_EmptyPublisher_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BookGenrePubl("C# in Depth", "Jon Skeet", 100, "Programming", ""));
        }
    }
}
