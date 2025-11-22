// Lab4ForT.Tests/RectangleTests.cs
using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void Constructor_ValidCoordinates_CreatesRectangle()
        {
            var rect = new Rectangle("Rect1", 0, 0, 5, 4);

            Assert.That(rect.Name, Is.EqualTo("Rect1"));
            Assert.That(rect.X1, Is.EqualTo(0));
            Assert.That(rect.Y1, Is.EqualTo(0));
            Assert.That(rect.X2, Is.EqualTo(5));
            Assert.That(rect.Y2, Is.EqualTo(4));
        }

        [Test]
        public void Area_ReturnsCorrectValue()
        {
            var rect = new Rectangle("Rect1", 0, 0, 5, 4);
            Assert.That(rect.Area(), Is.EqualTo(20));
        }

        [Test]
        public void Constructor_X2LessOrEqualX1_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle("Rect1", 5, 0, 5, 4));
            Assert.Throws<ArgumentException>(() => new Rectangle("Rect1", 6, 0, 5, 4));
        }

        [Test]
        public void Constructor_Y2LessOrEqualY1_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Rectangle("Rect1", 0, 4, 5, 4));
            Assert.Throws<ArgumentException>(() => new Rectangle("Rect1", 0, 5, 5, 4));
        }
    }
}
