using System;

class Task5
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int reversed = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number = number / 10;
        }

        Console.WriteLine("Перевернуте число: " + reversed);
    }
}
