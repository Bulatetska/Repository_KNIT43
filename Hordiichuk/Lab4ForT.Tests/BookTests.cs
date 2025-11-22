// Lab4ForT.Tests/BookTests.cs
using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Constructor_ValidArguments_CreatesBook()
        {
            var book = new Book("C# in Depth", "Jon Skeet", 100);

            Assert.That(book.Title, Is.EqualTo("C# in Depth"));
            Assert.That(book.Author, Is.EqualTo("Jon Skeet"));
            Assert.That(book.Price, Is.EqualTo(100));
        }

        [Test]
        public void Constructor_EmptyTitle_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Jon Skeet", 100));
        }

        [Test]
        public void Constructor_EmptyAuthor_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Book("C# in Depth", "", 100));
        }

        [Test]
        public void Constructor_NegativePrice_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Book("C# in Depth", "Jon Skeet", -10));
        }
    }
}
