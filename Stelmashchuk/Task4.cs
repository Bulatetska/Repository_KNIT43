using System;

class Task4
{
    static void Main()
    {
        Console.Write("Введіть число a (a < 100): ");
        int a = Convert.ToInt32(Console.ReadLine());

        if (a < 10)
        {
            Console.WriteLine("Кількість цифр: 1");
            Console.WriteLine("Сума цифр: " + a);
        }
        else
        {
            int firstDigit = a / 10;
            int secondDigit = a % 10;
            int sum = firstDigit + secondDigit;

            Console.WriteLine("Кількість цифр: 2");
            Console.WriteLine("Сума цифр: " + sum);
        }
    }
}
