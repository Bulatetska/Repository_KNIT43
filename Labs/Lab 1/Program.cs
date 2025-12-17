using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1. Середнє арифметичне двох чисел");
            Console.WriteLine("2. Вивести текст");
            Console.WriteLine("3. Перевірка числа на парність");
            Console.WriteLine("4. Кількість цифр і сума цифр (a < 100)");
            Console.WriteLine("5. Перевернути число");
            Console.WriteLine("6. Сума цифр числа");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть пункт меню: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    AverageOfTwoNumbers();
                    break;

                case 2:
                    PrintText();
                    break;

                case 3:
                    CheckEven();
                    break;

                case 4:
                    DigitsInfo();
                    break;

                case 5:
                    ReverseNumber();
                    break;

                case 6:
                    SumDigits();
                    break;

                case 0:
                    Console.WriteLine("Вихід...");
                    return;

                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    // === 1. Середнє арифметичне ===
    static void AverageOfTwoNumbers()
    {
        Console.Write("Введіть перше число: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = double.Parse(Console.ReadLine());

        double average = (a + b) / 2;
        Console.WriteLine("Середнє арифметичне: " + average);
    }

    // === 2. Вивести текст ===
    static void PrintText()
    {
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
    }

    // === 3. Перевірка числа на парність ===
    static void CheckEven()
    {
        Console.Write("Введіть число: ");
        int number = int.Parse(Console.ReadLine());

        if (number % 2 == 0)
            Console.WriteLine("Число парне");
        else
            Console.WriteLine("Число непарне");
    }

    // === 4. Кількість цифр і сума цифр числа < 100 ===
    static void DigitsInfo()
    {
        Console.Write("Введіть натуральне число (a < 100): ");
        int a = int.Parse(Console.ReadLine());

        string s = a.ToString();
        int count = s.Length;

        int sum = 0;
        foreach (char c in s)
            sum += c - '0';

        Console.WriteLine("Кількість цифр: " + count);
        Console.WriteLine("Сума цифр: " + sum);
    }

    // === 5. Перевернути число ===
    static void ReverseNumber()
    {
        Console.Write("Введіть число: ");
        string num = Console.ReadLine();

        char[] arr = num.ToCharArray();
        Array.Reverse(arr);

        Console.WriteLine("Перевернуте число: " + new string(arr));
    }

    // === 6. Сума цифр числа ===
    static void SumDigits()
    {
        Console.Write("Введіть число: ");
        string num = Console.ReadLine();

        int sum = 0;
        foreach (char c in num)
            sum += c - '0';

        Console.WriteLine("Сума цифр: " + sum);
    }
}
