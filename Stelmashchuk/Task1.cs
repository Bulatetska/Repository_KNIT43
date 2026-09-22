using System;

class Task1
{
    static void Main()
    {
        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double result = (a + b) / 2;

        Console.WriteLine("Середнє арифметичне: " + result);
    }
}
