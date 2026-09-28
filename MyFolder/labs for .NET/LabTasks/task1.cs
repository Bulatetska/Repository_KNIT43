using System;

class Task1
{
    public static void Run()
    {
        Console.Write("a = ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("b = ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Середнє: {(a + b) / 2}");
    }
}
