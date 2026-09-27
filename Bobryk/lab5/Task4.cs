using System;

class Figure
{
    protected string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public void Display()
    {
        Console.WriteLine("Фігура: " + name);
    }
}


class Rectangle : Figure
{
    protected double x1;
    protected double y1;
    protected double x2;
    protected double y2;

    public Rectangle(string name, double x1, double y1, double x2, double y2)
        : base(name)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public Rectangle()
        : this("Прямокутник", 0, 0, 1, 1)
    {
    }

    public new void Display()
    {
        base.Display();

        Console.WriteLine("Лівий верхній кут: (" + x1 + "; " + y1 + ")");
        Console.WriteLine("Правий нижній кут: (" + x2 + "; " + y2 + ")");
    }

    public double Area()
    {
        double width = Math.Abs(x2 - x1);
        double height = Math.Abs(y2 - y1);

        return width * height;
    }
}


class RectangleColor : Rectangle
{
    private string color;

    public RectangleColor(
        string name,
        double x1,
        double y1,
        double x2,
        double y2,
        string color)
        : base(name, x1, y1, x2, y2)
    {
        this.color = color;
    }

    public RectangleColor()
        : this("Кольоровий прямокутник", 0, 0, 1, 1, "Білий")
    {
    }

    public new void Display()
    {
        base.Display();

        Console.WriteLine("Колір: " + color);
    }

    public new double Area()
    {
        return base.Area();
    }
}


class Program
{
    static void Main()
    {
        Rectangle rectangle = new Rectangle(
            "Прямокутник",
            0,
            0,
            5,
            3
        );

        RectangleColor rectangleColor = new RectangleColor(
            "Кольоровий прямокутник",
            1,
            1,
            6,
            4,
            "Червоний"
        );


        Console.WriteLine("Перший прямокутник:");

        rectangle.Display();

        Console.WriteLine("Площа: " + rectangle.Area());


        Console.WriteLine("\nКольоровий прямокутник:");

        rectangleColor.Display();

        Console.WriteLine("Площа: " + rectangleColor.Area());


        Console.WriteLine("\nЧерез посилання Figure:");

        Figure figure;

        figure = rectangle;

        ((Rectangle)figure).Display();


        Console.WriteLine();


        figure = rectangleColor;

        ((RectangleColor)figure).Display();
    }
}