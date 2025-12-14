using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nОберіть завдання:");
            Console.WriteLine("1 - Середнє арифметичне двох чисел");
            Console.WriteLine("2 - Вивести текст");
            Console.WriteLine("3 - Перевірка числа на парність");
            Console.WriteLine("4 - Кількість і сума цифр числа");
            Console.WriteLine("5 - Перевернути число");
            Console.WriteLine("6 - Сума цифр числа");
            Console.WriteLine("0 - Вихід");
            Console.Write("Оберіть завдання: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Помилка!");
                continue;
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Average();
                    break;
                case 2:
                    PrintText();
                    break;
                case 3:
                    EvenCheck();
                    break;
                case 4:
                    CountAndSumDigits();
                    break;
                case 5:
                    ReverseNumber();
                    break;
                case 6:
                    SumDigits();
                    break;
                case 0:
                    Console.WriteLine("Програма завершена.");
                    return;
                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        }
    }

    static void Average()
    {
        Console.Write("Введіть перше число: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine($"Середнє арифметичне: {(a + b) / 2}");
    }

    static void PrintText()
    {
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
    }

    static void EvenCheck()
    {
        Console.Write("Введіть число: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(n % 2 == 0 ? "Число парне" : "Число непарне");
    }

    static void CountAndSumDigits()
    {
        Console.Write("Введіть натуральне число (a < 100): ");
        int a = int.Parse(Console.ReadLine());

        int count = 0, sum = 0, temp = a;

        while (temp > 0)
        {
            sum += temp % 10;
            count++;
            temp /= 10;
        }

        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}");
    }

    static void ReverseNumber()
    {
        Console.Write("Введіть число: ");
        int n = int.Parse(Console.ReadLine());

        int reversed = 0;
        while (n > 0)
        {
            reversed = reversed * 10 + n % 10;
            n /= 10;
        }

        Console.WriteLine($"Перевернуте число: {reversed}");
    }

    static void SumDigits()
    {
        Console.Write("Введіть число: ");
        int n = int.Parse(Console.ReadLine());

        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }

        Console.WriteLine($"Сума цифр числа: {sum}");
    }
}
