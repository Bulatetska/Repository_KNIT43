using System;

class Square
{
    public int X { get; set; }
    public int Y { get; set; }
    public double Side { get; set; }

    public Square(int x, int y, double side)
    {
        X = x;
        Y = y;
        Side = side;
    }

    public void IncreaseSide(double value)
    {
        Side += value;
        Console.WriteLine($"Сторона квадрата збільшена до: {Side}");
    }

    public override string ToString()
    {
        return $"Square: X={X}, Y={Y}, Side={Side}";
    }
}

class Cub : Square
{
    public double Height { get; set; }

    public Cub(int x, int y, double side, double height) : base(x, y, side)
    {
        Height = height;
    }

    public override string ToString()
    {
        return $"Cub: X={X}, Y={Y}, Side={Side}, Height={Height}";
    }
}

class Program
{
    static void Main()
    {
        Square sq = new Square(0, 0, 5);
        Console.WriteLine(sq);
        sq.IncreaseSide(3);

        Cub cube = new Cub(1, 1, 4, 6);
        Console.WriteLine(cube);
        cube.IncreaseSide(2);
        Console.WriteLine(cube);
    }
}
