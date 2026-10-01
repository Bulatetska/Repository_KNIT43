using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        Console.WriteLine("The sum of digits is: " + sum);
    }
}