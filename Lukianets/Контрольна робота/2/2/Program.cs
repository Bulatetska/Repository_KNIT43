using System;

class Program
{
    static void Main()
    {
        Cub myCube = new Cub(10, 20, 5.0);

        myCube.DemonstrateSideIncrease(3.5);
        myCube.DemonstrateSideIncrease(1.0);
    }
}


public class Square
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Side { get; set; }

    public Square(double x, double y, double side)
    {
        X = x;
        Y = y;
        Side = Math.Max(0, side);
    }
    
    public virtual void IncreaseSide(double delta)
    {
        if (delta > 0)
        {
            Side += delta;
            Console.WriteLine($"-> Сторона квадрата збільшена на {delta}. Нова сторона: {Side}");
        }
        else
        {
            Console.WriteLine("-> Збільшення сторони не відбулося (delta має бути > 0).");
        }
    }
}


public class Cub : Square
{
    public Cub(double x, double y, double side) : base(x, y, side)
    {
        Console.WriteLine($"Куб створено з початковою стороною: {Side}");
    }

    public void DemonstrateSideIncrease(double delta)
    {
        double oldSide = Side;
        
        Console.WriteLine($"\n*** Демонстрація для Куба ***");
        Console.WriteLine($"Початкове ребро Куба: {oldSide}");

        base.IncreaseSide(delta); 

        Console.WriteLine($"Після збільшення, нове ребро Куба: {Side}");
        Console.WriteLine($"-----------------------------------");
    }
}