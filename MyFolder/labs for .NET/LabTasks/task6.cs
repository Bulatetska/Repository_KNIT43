using System;

class Task6
{
    public static void Run()
    {
        Console.Write("Число: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int sum = 0;

        while (n > 0)
        {
            sum += n % 10;  // додали останню цифру до суми
            n = n / 10;     // викинули її
        }

        Console.WriteLine($"Сума цифр: {sum}");
    }
}