using System;

abstract class Figure
{
    public abstract double Area();

    public virtual void Print()
    {
        Console.WriteLine("Figure");
    }
}

class Triangle : Figure
{
    protected double a;
    protected double b;
    protected double c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double Area2
    {
        get
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    public override double Area()
    {
        return Area2;
    }

    public override void Print()
    {
        Console.WriteLine("Triangle:");
        Console.WriteLine($"Side a = {a}");
        Console.WriteLine($"Side b = {b}");
        Console.WriteLine($"Side c = {c}");
        Console.WriteLine($"Area = {Area()}");
    }
}

class TriangleColor : Triangle
{
    private string color;

    public TriangleColor(double a, double b, double c, string color)
        : base(a, b, c)
    {
        this.color = color;
    }

    public string Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
        }
    }

    public new double Area2
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
        Console.WriteLine($"Color = {color}");
    }
}

class Program
{
    static void Main()
    {
        TriangleColor triangle = new TriangleColor(3, 4, 5, "Red");

        triangle.Print();

        Console.WriteLine($"Area2 = {triangle.Area2}");
        Console.WriteLine($"Area() = {triangle.Area()}");

        triangle.Color = "Blue";

        Console.WriteLine();
        Console.WriteLine("After changing color:");
        triangle.Print();
    }
}