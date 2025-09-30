// Лабораторна робота №1 (завдання 1-6)

using System;
namespace Lab1App
{
    class Program
    {
        static void Main(string[] args)
        {
// 1. Напишіть програму, яка обчислює середнє арифметичне двох чисел.
        Console.WriteLine("Вправа 1");
        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double avg = (a + b) / 2;
        Console.WriteLine($"Середнє арифметичне = {avg}");

// 2. Виведіть на екран наступний текст:
// To be or not to be
// \ Shakespeare \
        Console.WriteLine("Вправа 2");
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");

        //  3. Напишіть програму, яка перевіряє число, введене з клавіатури на парність.
        Console.WriteLine("Вправа 3");
        Console.Write("Введіть число: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num % 2 == 0)
            Console.WriteLine("Число парне");
        else
            Console.WriteLine("Число непарне");

//  4. Дано натуральне число а (a <100). Напишіть програму, що виводить на екран кількість цифр в цьому числі і суму цих цифр
        Console.WriteLine("Вправа 4");
        Console.Write("Введіть число (a < 100): ");
        int n = Convert.ToInt32(Console.ReadLine());

        int count;
        int sum;

        if (n < 10)
        {
            count = 1;
            sum = n;
        }
        else
        {
            count = 2;
            sum = (n / 10) + (n % 10);
        }

        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}");

//  5.  Користувач вводить з клавіатури число, необхідно перевернути його (число) і вивести на екран.
        Console.WriteLine("Вправа 5");
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int reversed = 0;
        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        Console.WriteLine($"Перевернуте число: {reversed}");

// 6. Користувач вводить з клавіатури число, необхідно показати на екран суму його цифр.
        Console.WriteLine("Вправа 6");
        Console.Write("Введіть число: ");
        int numeric = Convert.ToInt32(Console.ReadLine());

        int total = 0;
        int temp = numeric;

        while (temp > 0)
        {
            total += temp % 10;
            temp /= 10;
        }

        Console.WriteLine($"Сума цифр числа {numeric} = {total}");
    }
    }
}