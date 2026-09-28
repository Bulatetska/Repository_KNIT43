using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть перше число: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = double.Parse(Console.ReadLine());

        double average = (a + b) / 2;
        Console.WriteLine($"Середнє арифметичне: {average}");
    }
}
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("To be or not to be");
        Console.WriteLine(@"\ Shakespeare \");
    }
}
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть ціле число: ");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("Число є парним.");
        }
        else
        {
            Console.WriteLine("Число є непарним.");
        }
    }
}
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть натуральне число a (a < 100): ");
        int a = int.Parse(Console.ReadLine());

        int count;
        int sum;

        if (a < 10)
        {
            count = 1;
            sum = a;
        }
        else
        {
            count = 2;
            sum = (a / 10) + (a % 10);
        }

        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}");
    }
}
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = int.Parse(Console.ReadLine());

        int reversed = 0;
        int temp = Math.Abs(number);

        while (temp > 0)
        {
            reversed = reversed * 10 + (temp % 10);
            temp /= 10;
        }

        if (number < 0) reversed = -reversed;

        Console.WriteLine($"Число навпаки: {reversed}");
    }
}
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        int temp = Math.Abs(number);

        while (temp > 0)
        {
            sum += temp % 10; // додаємо останню цифру
            temp /= 10;       // прибираємо останню цифру
        }

        Console.WriteLine($"Сума цифр числа: {sum}");
    }
}