using Lab5Classes.Models;
using NUnit.Framework;

namespace Lab9Tests;

[TestFixture, NonParallelizable]
public class FigureTests
{
    [Test]
    public void Figure_Display_ShowsName()
    {
        var figure = new Figure("Фігура");
        Assert.That(ConsoleOutput.Capture(figure.Display), Does.Contain("Назва фігури: Фігура"));
    }

    [TestCase(1, 2, 6, 5, 15)]
    [TestCase(6, 5, 1, 2, 15)]
    [TestCase(-2, -3, 2, 3, 24)]
    [TestCase(1, 1, 1, 5, 0)]
    public void Rectangle_Area_ReturnsExpected(double x1, double y1, double x2, double y2, double expected)
    {
        var rectangle = new Rectangle("Прямокутник", x1, y1, x2, y2);
        Assert.That(rectangle.Area(), Is.EqualTo(expected).Within(0.000001));
    }

    [Test]
    public void Rectangle_DefaultConstructor_SetsUnitArea()
    {
        var rectangle = new Rectangle();
        Assert.That(rectangle.X1, Is.Zero);
        Assert.That(rectangle.Y1, Is.Zero);
        Assert.That(rectangle.X2, Is.EqualTo(1));
        Assert.That(rectangle.Y2, Is.EqualTo(1));
        Assert.That(rectangle.Area(), Is.EqualTo(1));
    }

    [Test]
    public void RectangleColor_Area_UsesBaseCalculation()
    {
        Rectangle rectangle = new RectangleColor("Кольоровий прямокутник", 0, 0, 4, 3, "синій");
        Assert.That(rectangle.Area(), Is.EqualTo(12));
    }

    [Test]
    public void RectangleColor_DefaultConstructor_SetsUnitArea()
    {
        var rectangle = new RectangleColor();
        Assert.That(rectangle.Area(), Is.EqualTo(1));
        Assert.That(rectangle.Color, Is.Not.Empty);
    }

    [Test]
    public void Rectangle_Display_ThroughFigureReference()
    {
        Figure figure = new Rectangle("Прямокутник", 1, 2, 6, 5);
        string text = ConsoleOutput.Capture(figure.Display);
        Assert.That(text, Does.Contain("Назва фігури: Прямокутник"));
        Assert.That(text, Does.Contain("(1; 2)"));
        Assert.That(text, Does.Contain("(6; 5)"));
    }

    [Test]
    public void RectangleColor_Display_ThroughFigureReference()
    {
        Figure figure = new RectangleColor("Кольоровий прямокутник", 0, 0, 4, 3, "синій");
        string text = ConsoleOutput.Capture(figure.Display);
        Assert.That(text, Does.Contain("Назва фігури: Кольоровий прямокутник"));
        Assert.That(text, Does.Contain("(4; 3)"));
        Assert.That(text, Does.Contain("Колір: синій"));
    }

    [Test]
    public void RectangleColor_Color_CanBeChanged()
    {
        var rectangle = new RectangleColor();
        rectangle.Color = "зелений";
        Assert.That(rectangle.Color, Is.EqualTo("зелений"));
    }
}
