
using System;

class Figure
{
    protected string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public virtual void Display()
    {
        Console.WriteLine("Фігура: " + name);
    }
}

class Rectangle : Figure
{
    protected double x1, y1, x2, y2;

    public Rectangle(string name, double x1, double y1,
                     double x2, double y2) : base(name)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Rectangle() : this("Прямокутник", 0, 0, 1, 1)
    {
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Лівий верхній кут: (" + x1 + "; " + y1 + ")");
        Console.WriteLine("Правий нижній кут: (" + x2 + "; " + y2 + ")");
    }

    public virtual double Area()
    {
        return Math.Abs((x2 - x1) * (y2 - y1));
    }
}

class RectangleColor : Rectangle
{
    private string color;

    public RectangleColor(string name, double x1, double y1,
                          double x2, double y2, string color)
        : base(name, x1, y1, x2, y2)
    {
        this.color = color;
    }

    public RectangleColor()
        : this("Кольоровий прямокутник", 0, 0, 1, 1, "Червоний")
    {
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine("Колір: " + color);
    }

    public override double Area()
    {
        return base.Area();
    }
}

class Program
{
    static void Main()
    {
        Figure figure;

        Rectangle rectangle = new Rectangle(
            "Прямокутник", 0, 0, 4, 3);

        RectangleColor colorRectangle = new RectangleColor(
            "Кольоровий прямокутник", 0, 0, 5, 2, "Синій");

        Console.WriteLine("Звичайний прямокутник:");

        figure = rectangle;
        figure.Display();
        Console.WriteLine("Площа: " + rectangle.Area());

        Console.WriteLine("\nКольоровий прямокутник:");

        figure = colorRectangle;
        figure.Display();
        Console.WriteLine("Площа: " + colorRectangle.Area());

        Console.WriteLine("\nПрямокутник без параметрів:");

        Rectangle defaultRectangle = new Rectangle();
        defaultRectangle.Display();
        Console.WriteLine("Площа: " + defaultRectangle.Area());

        Console.WriteLine("\nКольоровий прямокутник без параметрів:");

        RectangleColor defaultColor = new RectangleColor();
        defaultColor.Display();
        Console.WriteLine("Площа: " + defaultColor.Area());
    }
}
