using System;

abstract class Figure
{
    public abstract double Area();
    public abstract void Print();
}

class Triangle : Figure
{
    private double a, b, c; 

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public double A { get => a; set => a = value; }
    public double B { get => b; set => b = value; }
    public double C { get => c; set => c = value; }

    public override double Area()
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public virtual double Area2
    {
        get { return Area(); }
    }

    public override void Print()
    {
        Console.WriteLine("Triangle:");
        Console.WriteLine($"  A = {a}, B = {b}, C = {c}");
        Console.WriteLine($"  Area = {Area()}");
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
        get => color;
        set => color = value;
    }

    public override double Area2
    {
        get { return base.Area2; }
    }

    public override double Area()
    {
        return base.Area();
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"  Color = {color}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TriangleColor t = new TriangleColor(3, 4, 5, "Red");
        t.Print();

        Console.ReadLine();
    }
}
