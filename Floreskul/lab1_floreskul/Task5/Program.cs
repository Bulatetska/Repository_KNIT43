using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int reversedNumber = 0;

        while (number > 0)
        {
            int digit = number % 10;

            reversedNumber = reversedNumber * 10 + digit;

            number = number / 10;
        }

        Console.WriteLine("Число навпаки: " + reversedNumber);
    }
}
