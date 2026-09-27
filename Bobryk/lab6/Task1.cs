using System;

abstract class Figure
{
    private string name;

    public Figure(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public abstract double Area2 { get; }

    public abstract double Area();

    public virtual void Print()
    {
        Console.WriteLine("Назва: " + name);
    }
}


class Triangle : Figure
{
    private double a;
    private double b;
    private double c;

    public Triangle(string name, double a, double b, double c)
        : base(name)
    {
        if (a + b > c && a + c > b && b + c > a)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            Console.WriteLine("Такого трикутника не існує" );
        }
    }

    public void SetABC(double a, double b, double c)
    {
        if (a + b > c && a + c > b && b + c > a)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            Console.WriteLine("Такого трикутника не існує" );
        }
    }

    public void GetABC(out double a, out double b, out double c)
    {
        a = this.a;
        b = this.b;
        c = this.c;
    }

    public override double Area2
    {
        get
        {
            double p = (a + b + c) / 2;

            return Math.Sqrt(
                p * (p - a) * (p - b) * (p - c)
            );
        }
    }

    public override double Area()
    {
        double p = (a + b + c) / 2;

        return Math.Sqrt(
            p * (p - a) * (p - b) * (p - c)
        );
    }

    public override void Print()
    {
        base.Print();

        Console.WriteLine("Сторона a: " + a);
        Console.WriteLine("Сторона b: " + b);
        Console.WriteLine("Сторона c: " + c);
    }
}


class TriangleColor : Triangle
{
    private int color;

    public TriangleColor(
        string name,
        double a,
        double b,
        double c,
        int color)
        : base(name, a, b, c)
    {
        if (color >= 0 && color <= 255)
        {
            this.color = color;
        }
        else
        {
            this.color = 0;
        }
    }

    public int Color
    {
        get { return color; }

        set
        {
            if (value >= 0 && value <= 255)
            {
                color = value;
            }
            else
            {
                color = 0;
            }
        }
    }

    public override double Area2
    {
        get
        {
            return base.Area2;
        }
    }

    public override double Area()
    {
        return base.Area();
    }

    public override void Print()
    {
        base.Print();

        Console.WriteLine("Колір: " + color);
    }
}


class Program
{
    static void Main()
    {
        Triangle triangle = new Triangle(
            "Трикутник",
            2,
            3,
            2
        );

        TriangleColor triangleColor = new TriangleColor(
            "Кольоровий трикутник",
            3,
            4,
            5,
            100
        );


        Console.WriteLine("Звичайний трикутник:");

        triangle.Print();

        Console.WriteLine("Площа через Area(): " + triangle.Area());
        Console.WriteLine("Площа через Area2: " + triangle.Area2);


        Console.WriteLine("\nКольоровий трикутник:");

        triangleColor.Print();

        Console.WriteLine("Площа через Area(): " + triangleColor.Area());
        Console.WriteLine("Площа через Area2: " + triangleColor.Area2);


        Console.WriteLine("\nЧерез посилання Figure:");

        Figure figure;

        figure = triangle;
        figure.Print();

        Console.WriteLine();

        figure = triangleColor;
        figure.Print();
    }
}