using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть натуральне число менше 100: ");
        int a = Convert.ToInt32(Console.ReadLine());

        if (a > 0 && a < 10)
        {
            Console.WriteLine("Кількість цифр: 1");
            Console.WriteLine("Сума цифр: " + a);
        }
        else if (a >= 10 && a < 100)
        {
            int firstDigit = a / 10;
            int secondDigit = a % 10;

            int sum = firstDigit + secondDigit;

            Console.WriteLine("Кількість цифр: 2");
            Console.WriteLine("Сума цифр: " + sum);
        }
        else
        {
            Console.WriteLine("Помилка! Число повинно бути натуральним і меншим за 100.");
        }
    }
}
