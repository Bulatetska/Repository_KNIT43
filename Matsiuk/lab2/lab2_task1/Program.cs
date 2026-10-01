using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double average = (a + b) / 2;

        Console.WriteLine("Arithmetic mean: " + average);
    }
}