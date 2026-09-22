using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        while (number > 0)
        {
            int digit = number % 10;

            sum = sum + digit;

            number = number / 10;
        }

        Console.WriteLine("Сума цифр числа = " + sum);
    }
}
