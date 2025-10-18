using NUnit.Framework;
using MyApp;
using System;

namespace FigureTests
{
    [TestFixture]
    public class FigureTests
    {
        [Test]
        public void Figure_SettersAndGetters_WorkCorrectly()
        {
            var figure = new Figure("Circle");
            Assert.That(figure.Name, Is.EqualTo("Circle"));

            figure.Name = "Triangle";
            Assert.That(figure.Name, Is.EqualTo("Triangle"));
        }

        [Test]
        public void Figure_Display_DoesNotThrow()
        {
            var figure = new Figure("Circle");
            Assert.DoesNotThrow(() => figure.Display());
        }
    }

    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void Rectangle_SettersAndGetters_WorkCorrectly()
        {
            var rect = new Rectangle("MyRect", 0, 0, 5, 10);

            Assert.That(rect.Name, Is.EqualTo("MyRect"));
            Assert.That(rect.X1, Is.EqualTo(0));
            Assert.That(rect.Y1, Is.EqualTo(0));
            Assert.That(rect.X2, Is.EqualTo(5));
            Assert.That(rect.Y2, Is.EqualTo(10));

            rect.Name = "NewRect";
            rect.X1 = 1;
            rect.Y1 = 2;
            rect.X2 = 6;
            rect.Y2 = 12;

            Assert.That(rect.Name, Is.EqualTo("NewRect"));
            Assert.That(rect.X1, Is.EqualTo(1));
            Assert.That(rect.Y1, Is.EqualTo(2));
            Assert.That(rect.X2, Is.EqualTo(6));
            Assert.That(rect.Y2, Is.EqualTo(12));
        }

        [Test]
        public void Rectangle_Display_DoesNotThrow()
        {
            var rect = new Rectangle("MyRect", 0, 0, 5, 10);
            Assert.DoesNotThrow(() => rect.Display());
        }

        [Test]
        public void Rectangle_Area_WorksCorrectly()
        {
            var rect = new Rectangle("MyRect", 0, 0, 5, 10);
            Assert.That(rect.Area(), Is.EqualTo(50));

            var rect2 = new Rectangle("MyRect2", 10, 5, 15, 15);
            Assert.That(rect2.Area(), Is.EqualTo(50));
        }
    }

    [TestFixture]
    public class RectangleColorTests
    {
        [Test]
        public void RectangleColor_SettersAndGetters_WorkCorrectly()
        {
            var coloredRect = new RectangleColor("ColorRect", 0, 0, 3, 4, "Red");

            Assert.That(coloredRect.Name, Is.EqualTo("ColorRect"));
            Assert.That(coloredRect.X1, Is.EqualTo(0));
            Assert.That(coloredRect.Y1, Is.EqualTo(0));
            Assert.That(coloredRect.X2, Is.EqualTo(3));
            Assert.That(coloredRect.Y2, Is.EqualTo(4));
            Assert.That(coloredRect.Color, Is.EqualTo("Red"));

            coloredRect.Name = "NewColorRect";
            coloredRect.X1 = 1;
            coloredRect.Y1 = 2;
            coloredRect.X2 = 4;
            coloredRect.Y2 = 6;
            coloredRect.Color = "Blue";

            Assert.That(coloredRect.Name, Is.EqualTo("NewColorRect"));
            Assert.That(coloredRect.X1, Is.EqualTo(1));
            Assert.That(coloredRect.Y1, Is.EqualTo(2));
            Assert.That(coloredRect.X2, Is.EqualTo(4));
            Assert.That(coloredRect.Y2, Is.EqualTo(6));
            Assert.That(coloredRect.Color, Is.EqualTo("Blue"));
        }

        [Test]
        public void RectangleColor_Display_DoesNotThrow()
        {
            var coloredRect = new RectangleColor("ColorRect", 0, 0, 3, 4, "Red");
            Assert.DoesNotThrow(() => coloredRect.Display());
        }

        [Test]
        public void RectangleColor_Area_WorksCorrectly()
        {
            var coloredRect = new RectangleColor("ColorRect", 0, 0, 3, 4, "Red");
            Assert.That(coloredRect.Area(), Is.EqualTo(12));
        }
    }
}