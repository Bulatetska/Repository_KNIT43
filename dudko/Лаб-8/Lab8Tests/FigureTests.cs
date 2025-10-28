using NUnit.Framework;
using ConsoleApplication8;

namespace Lab8Tests
{
    [TestFixture]
    public class FigureTests
    {
        [Test]
        public void Triangle_CorrectSides_AreaIsCorrect()
        {
            Triangle t = new Triangle("Triangle", 3, 4, 5);
            double expected = 6;
            Assert.That(t.Area(), Is.EqualTo(expected).Within(0.001));
            Assert.That(t.Area2, Is.EqualTo(expected).Within(0.001));
        }

        [Test]
        public void Triangle_IncorrectSides_DefaultToOne()
        {
            Triangle t = new Triangle("Triangle", 1, 2, 10);
            double expected = 0.433;
            Assert.That(t.Area(), Is.EqualTo(expected).Within(0.001));
        }

        [Test]
        public void TriangleColor_ColorProperty_Works()
        {
            TriangleColor tc = new TriangleColor("Colored Triangle", 3, 4, 5, "Red");
            Assert.That(tc.Color, Is.EqualTo("Red"));
            tc.Color = "Blue";
            Assert.That(tc.Color, Is.EqualTo("Blue"));
        }
    }
}
