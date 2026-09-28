using System;

class Task5
{
    public static void Run()
    {
        Console.Write("Число: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int rev = 0;

        while (n > 0)
        {
            int digit = n % 10;       // взяли останню цифру
            rev = (rev * 10) + digit; // приписали її в кінець нового числа
            n = n / 10;               // викинули останню цифру з n
        }

        Console.WriteLine($"Результат: {rev}");
    }
}