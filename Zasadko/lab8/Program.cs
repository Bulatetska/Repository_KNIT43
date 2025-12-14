using System;
using Xunit;
using OOP_Examples;

namespace Lab8
{
    public class PersonTests
    {
        [Fact]
        public void PersonProperties_ShouldSetAndGetValues()
        {
            var person = new Person();
            person.Name = "Ivan";
            person.Age = 25;
            person.Gender = "Male";
            person.Phone = "+380123456789";

            Assert.Equal("Ivan", person.Name);
            Assert.Equal(25, person.Age);
            Assert.Equal("Male", person.Gender);
            Assert.Equal("+380123456789", person.Phone);
        }
    }

    public class StudentTests
    {
        [Fact]
        public void StudentPrint_ShouldReturnCorrectValues()
        {
            var student = new Student("Ivanov", 3, "RB123");
            Assert.Equal("Ivanov", student.Surname);
            Assert.Equal(3, student.Course);
            Assert.Equal("RB123", student.RecordBook);
        }

        [Fact]
        public void Aspirant_ShouldIncludeResearchTopic()
        {
            var aspirant = new Aspirant("Petrov", 1, "RB456", "AI Research");
            Assert.Equal("AI Research", aspirant.ResearchTopic);
        }
    }

    public class BookTests
    {
        [Fact]
        public void BookGenrePubl_ShouldHaveAllProperties()
        {
            var book = new BookGenrePubl("C# in Depth", "Jon Skeet", 45.99m, "Programming", "Manning");
            Assert.Equal("C# in Depth", book.Title);
            Assert.Equal("Jon Skeet", book.Author);
            Assert.Equal(45.99m, book.Price);
            Assert.Equal("Programming", book.Genre);
            Assert.Equal("Manning", book.Publisher);
        }
    }

    public class RectangleTests
    {
        [Fact]
        public void RectangleArea_ShouldBeCorrect()
        {
            var rect = new Rectangle(0, 0, 3, 4, "Rect1");
            Assert.Equal(12, rect.Area());
        }

        [Fact]
        public void RectangleColorArea_ShouldBeCorrect()
        {
            var rectColor = new RectangleColor(0, 0, 2, 5, "Rect2", "Blue");
            Assert.Equal(10, rectColor.Area());
            Assert.Equal("Blue", rectColor.Color);
        }
    }

    public class VectorTests
    {
        [Fact]
        public void VectorOperations_ShouldWorkCorrectly()
        {
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            // Unary minus
            Vector vNeg = -v1;
            Assert.Equal(-3, vNeg.X);
            Assert.Equal(-4, vNeg.Y);

            // Addition
            Vector vSum = vNeg + v2;
            Assert.Equal(-2, vSum.X);
            Assert.Equal(-6, vSum.Y);

            // Multiplication
            Vector vMul = v2 * 2;
            Assert.Equal(2, vMul.X);
            Assert.Equal(-4, vMul.Y);

            // Equality
            Vector v3 = new Vector(-3, -4);
            Assert.True(v1 != v3); // v1 = (3,4), v3 = (-3,-4)
        }

        [Fact]
        public void VectorLength_ShouldReturnCorrectValue()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(5, v.Length());
        }
    }
}
