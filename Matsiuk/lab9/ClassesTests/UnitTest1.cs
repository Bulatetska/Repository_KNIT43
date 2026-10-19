using System;
using System.IO;
using NUnit.Framework;
using ClassesLibrary;

namespace ClassesTests
{
    [TestFixture]
    public class UnitTest1
    {
        private StringWriter output;
        private TextWriter originalOutput;

        [SetUp]
        public void SetUp()
        {
            originalOutput = Console.Out;
            output = new StringWriter();
            Console.SetOut(output);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(originalOutput);
            output.Dispose();
        }

        // Person tests

        [Test]
        public void Person_SetAge_ChangesPrintedAge()
        {
            Person person = new Person("John", 20, "Male", "12345");

            person.SetAge(21);
            person.Print();

            Assert.That(output.ToString(), Does.Contain("Age: 21"));
        }

        [Test]
        public void Person_SetName_ChangesPrintedName()
        {
            Person person = new Person("John", 20, "Male", "12345");

            person.SetName("Michael");
            person.Print();

            Assert.That(output.ToString(), Does.Contain("Name: Michael"));
        }

        [Test]
        public void Person_SetGenderAndPhone_ChangesPrintedData()
        {
            Person person = new Person("John", 20, "Male", "12345");

            person.SetGender("Female");
            person.SetPhone("98765");
            person.Print();

            Assert.That(output.ToString(), Does.Contain("Gender: Female"));
            Assert.That(output.ToString(), Does.Contain("Phone: 98765"));
        }

        // Student and Aspirant tests

        [Test]
        public void Student_Constructor_SetsProperties()
        {
            Student student = new Student("Smith", 3, "ST123");

            Assert.Multiple(() =>
            {
                Assert.That(student.Surname, Is.EqualTo("Smith"));
                Assert.That(student.Course, Is.EqualTo(3));
                Assert.That(student.StudentBookNumber, Is.EqualTo("ST123"));
            });
        }

        [Test]
        public void Aspirant_InheritsStudentData()
        {
            Aspirant aspirant = new Aspirant(
                "Brown", 5, "AS123", "Computer Science");

            Assert.Multiple(() =>
            {
                Assert.That(aspirant.Surname, Is.EqualTo("Brown"));
                Assert.That(aspirant.Course, Is.EqualTo(5));
                Assert.That(aspirant.StudentBookNumber, Is.EqualTo("AS123"));
                Assert.That(aspirant.DissertationTopic,
                    Is.EqualTo("Computer Science"));
            });
        }

        [Test]
        public void Aspirant_Print_DisplaysDissertationTopic()
        {
            Aspirant aspirant = new Aspirant(
                "Brown", 5, "AS123", "Computer Science");

            aspirant.Print();

            Assert.That(output.ToString(),
                Does.Contain("Dissertation topic: Computer Science"));
        }

        // Book tests

        [Test]
        public void Book_Constructor_SetsProperties()
        {
            Book book = new Book("C# Basics", "John Smith", 250.50);

            Assert.Multiple(() =>
            {
                Assert.That(book.Title, Is.EqualTo("C# Basics"));
                Assert.That(book.Author, Is.EqualTo("John Smith"));
                Assert.That(book.Price, Is.EqualTo(250.50));
            });
        }

        [Test]
        public void BookGenre_Print_DisplaysGenre()
        {
            BookGenre book = new BookGenre(
                "C# Basics", "John Smith", 250, "Education");

            book.Print();

            Assert.That(output.ToString(), Does.Contain("Genre: Education"));
        }

        [Test]
        public void BookGenrePubl_Print_DisplaysPublisher()
        {
            BookGenrePubl book = new BookGenrePubl(
                "C# Basics", "John Smith", 250, "Education", "Tech Books");

            book.Print();

            Assert.That(output.ToString(), Does.Contain("Publisher: Tech Books"));
        }

        // Rectangle tests

        [Test]
        public void Rectangle_Area_ReturnsCorrectValue()
        {
            Rectangle rectangle = new Rectangle("Rectangle", 0, 0, 5, 3);

            Assert.That(rectangle.Area(), Is.EqualTo(15));
        }

        [Test]
        public void Rectangle_DefaultConstructor_ReturnsAreaOne()
        {
            Rectangle rectangle = new Rectangle();

            Assert.That(rectangle.Area(), Is.EqualTo(1));
        }

        [Test]
        public void RectangleColor_Area_ReturnsCorrectValue()
        {
            RectangleColor rectangle = new RectangleColor(
                "Rectangle", 0, 0, 4, 2, "Blue");

            Assert.That(rectangle.Area(), Is.EqualTo(8));
        }

        [Test]
        public void RectangleColor_DefaultConstructor_SetsDefaultColor()
        {
            RectangleColor rectangle = new RectangleColor();

            Assert.Multiple(() =>
            {
                Assert.That(rectangle.Color, Is.EqualTo("Red"));
                Assert.That(rectangle.Area(), Is.EqualTo(1));
            });
        }

        [Test]
        public void RectangleColor_Display_IncludesColorAndFigureName()
        {
            RectangleColor rectangle = new RectangleColor(
                "Colored Rectangle", 0, 0, 4, 2, "Blue");

            rectangle.Display();

            Assert.Multiple(() =>
            {
                Assert.That(output.ToString(),
                    Does.Contain("Figure: Colored Rectangle"));
                Assert.That(output.ToString(), Does.Contain("Color: Blue"));
            });
        }

        [Test]
        public void FigureReference_CallsDerivedDisplayMethod()
        {
            Figure figure = new RectangleColor(
                "Colored Rectangle", 0, 0, 4, 2, "Blue");

            figure.Display();

            Assert.That(output.ToString(), Does.Contain("Color: Blue"));
        }
    }
}