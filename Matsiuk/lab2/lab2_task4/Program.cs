using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a natural number (a < 100): ");
        int a = Convert.ToInt32(Console.ReadLine());

        int number = a;
        int count = 0;
        int sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            count++;
            number /= 10;
        }

        Console.WriteLine("Number of digits: " + count);
        Console.WriteLine("Sum of digits: " + sum);
    }
}