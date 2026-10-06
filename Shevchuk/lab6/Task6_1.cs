using System;

abstract class AbstractFigure
{
    private string name;

    public AbstractFigure(string name)
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
        Console.WriteLine("name = {0}", name);
    }
}

class AbstractTriangle : AbstractFigure
{
    private double a, b, c;

    public AbstractTriangle(string name, double a, double b, double c) : base(name)
    {
        if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            Console.WriteLine("Incorrect values a, b, c. By default: 1, 1, 1.");
            this.a = this.b = this.c = 1;
        }
    }

    public void SetABC(double a, double b, double c)
    {
        if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            this.a = this.b = this.c = 1;
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
            double p = (a + b + c) / 2.0;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);
            return s;
        }
    }

    public override double Area()
    {
        double p = (a + b + c) / 2.0;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        Console.WriteLine("Method Triangle.Area(): s = {0:f3}", s);
        return s;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("a = {0:f2}", a);
        Console.WriteLine("b = {0:f2}", b);
        Console.WriteLine("c = {0:f2}", c);
    }
}

class AbstractTriangleColor : AbstractTriangle
{
    private int color;

    public AbstractTriangleColor(string name, double a, double b, double c, int color)
        : base(name, a, b, c)
    {
        if (color >= 0 && color <= 255)
            this.color = color;
        else
            this.color = 0;
    }

    public int Color
    {
        get { return color; }
        set
        {
            if (value >= 0 && value <= 255)
                color = value;
            else
                color = 0;
        }
    }

    public override double Area2
    {
        get
        {
            Console.WriteLine("Property TriangleColor.Area2:");
            return base.Area2;
        }
    }

    public override double Area()
    {
        Console.WriteLine("Method TriangleColor.Area():");
        return base.Area();
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("color = {0}", color);
    }
}

class Task6_1
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\n=== Завдання 6.1: AbstractFigure -> Triangle -> TriangleColor ===");

        AbstractFigure refFg;

        AbstractTriangle Tr = new AbstractTriangle("Triangle", 2, 3, 2);
        AbstractTriangleColor TrCol = new AbstractTriangleColor("TriangleColor", 1, 3, 3, 0);

        Console.WriteLine("--- Демонстрація Print() ---");
        refFg = Tr;
        refFg.Print();
        Console.WriteLine();

        refFg = TrCol;
        refFg.Print();
        Console.WriteLine();

        Console.WriteLine("--- Демонстрація Area() ---");
        refFg = Tr;
        refFg.Area();
        Console.WriteLine();

        refFg = TrCol;
        refFg.Area();
        Console.WriteLine();

        Console.WriteLine("--- Демонстрація Area2 ---");
        refFg = Tr;
        double area1 = refFg.Area2;
        Console.WriteLine("area = {0:f3}\n", area1);

        refFg = TrCol;
        double area2 = refFg.Area2;
        Console.WriteLine("area = {0:f3}", area2);
    }
}
