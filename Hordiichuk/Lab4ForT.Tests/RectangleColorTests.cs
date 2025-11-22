// Lab4ForT.Tests/RectangleColorTests.cs
using NUnit.Framework;
using Lab4ForT;
using System;

namespace Lab4ForT.Tests
{
    [TestFixture]
    public class RectangleColorTests
    {
        [Test]
        public void Constructor_ValidArguments_CreatesRectangleColor()
        {
            var rect = new RectangleColor("RectColor", 0, 0, 5, 4, "Red");

            Assert.That(rect.Name, Is.EqualTo("RectColor"));
            Assert.That(rect.X1, Is.EqualTo(0));
            Assert.That(rect.Y1, Is.EqualTo(0));
            Assert.That(rect.X2, Is.EqualTo(5));
            Assert.That(rect.Y2, Is.EqualTo(4));
            Assert.That(rect.Color, Is.EqualTo("Red"));
        }

        [Test]
        public void Constructor_EmptyColor_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RectangleColor("RectColor", 0, 0, 5, 4, ""));
        }

        [Test]
        public void Area_ReturnsCorrectValue()
        {
            var rect = new RectangleColor("RectColor", 0, 0, 5, 4, "Red");
            Assert.That(rect.Area(), Is.EqualTo(20));
        }
    }
}
