using NUnit.Framework;
using System;
using PersonClass;
using StudentClasses;
using BookClasses;
using FigureClasses;

namespace Test_Person
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void PersonProperties_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var person = new Person("Alice", 25, "Female", "+380501234567");

            // Act
            person.Name = "Bob";
            person.Age = 30;
            person.Gender = "Male";
            person.PhoneNumber = "+380501112233";

            // Assert
            Assert.That(person.Name, Is.EqualTo("Bob"));
            Assert.That(person.Age, Is.EqualTo(30));
            Assert.That(person.Gender, Is.EqualTo("Male"));
            Assert.That(person.PhoneNumber, Is.EqualTo("+380501112233"));
        }
    }
}

namespace Test_Student
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void StudentProperties_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var student = new Student("Ivanov", 2, "RB12345");

            // Act
            student.Surname = "Petrov";
            student.Course = 3;
            student.RecordBookNumber = "RB54321";

            // Assert
            Assert.That(student.Surname, Is.EqualTo("Petrov"));
            Assert.That(student.Course, Is.EqualTo(3));
            Assert.That(student.RecordBookNumber, Is.EqualTo("RB54321"));
        }

        [Test]
        public void Aspirant_InheritsStudentPropertiesCorrectly()
        {
            // Arrange
            var aspirant = new Aspirant("Sidorov", 4, "RB99999");

            // Act
            aspirant.Surname = "Sidorov";
            aspirant.Course = 4;
            aspirant.RecordBookNumber = "RB99999";

            // Assert
            Assert.That(aspirant.Surname, Is.EqualTo("Sidorov"));
            Assert.That(aspirant.Course, Is.EqualTo(4));
            Assert.That(aspirant.RecordBookNumber, Is.EqualTo("RB99999"));
        }
    }
}

namespace Test_Book
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void BookProperties_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var book = new Book("Title1", "Author1", 10.5);

            // Act
            book.Title = "Title2";
            book.Author = "Author2";
            book.Price = 15.0;

            // Assert
            Assert.That(book.Title, Is.EqualTo("Title2"));
            Assert.That(book.Author, Is.EqualTo("Author2"));
            Assert.That(book.Price, Is.EqualTo(15.0));
        }

        [Test]
        public void BookGenreProperties_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var genreBook = new BookGenre("TitleG", "AuthorG", 20.0, "Sci-Fi");

            // Act
            genreBook.Genre = "Fantasy";

            // Assert
            Assert.That(genreBook.Genre, Is.EqualTo("Fantasy"));
        }

        [Test]
        public void BookGenrePublProperties_ShouldSetAndGetCorrectly()
        {
            // Arrange
            var publBook = new BookGenrePubl("TitleP", "AuthorP", 25.0, "Mystery", "Publisher1");

            // Act
            publBook.Publisher = "Publisher2";

            // Assert
            Assert.That(publBook.Publisher, Is.EqualTo("Publisher2"));
        }
    }
}


namespace Test_Figure
{
    [TestFixture]
    public class FigureTests
    {
        [Test]
        public void RectangleArea_ShouldReturnCorrectValue()
        {
            // Arrange
            var rect = new Rectangle(0, 0, 4, 5, "Rect");

            // Assert
            Assert.That(rect.Area(), Is.EqualTo(20));
        }

        [Test]
        public void RectangleColorArea_ShouldReturnCorrectValue()
        {
            // Arrange
            var coloredRect = new RectangleColor(1, 1, 6, 7, "Colored", "Blue");

            // Assert
            Assert.That(coloredRect.Area(), Is.EqualTo(30));
        }


        [Test]
        public void FigureDisplay_ShouldHaveName()
        {
            // Arrange
            var figure = new Figure("MyFigure");

            // Assert
            Assert.That(figure, Is.Not.Null);
        }
    }
}
