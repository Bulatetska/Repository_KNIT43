using System;

class Task4
{
    public static void Run()
    {
        Console.Write("a < 100: ");
        int a = Convert.ToInt32(Console.ReadLine());

        if (a < 10)
        {
            Console.WriteLine($"Кількість: 1, Сума: {a}");
        }
        else
        {
            int first = a / 10;   // перша цифра (десятки)
            int second = a % 10;  // друга цифра (одиниці)
            Console.WriteLine($"Кількість: 2, Сума: {first + second}");
        }
    }
}