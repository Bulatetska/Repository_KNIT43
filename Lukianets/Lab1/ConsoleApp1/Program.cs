using System;

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
    }

    // 1. Середнє арифметичне двох чисел
    static void Task1()
    {
        Console.WriteLine("=== Завдання 1 ===");
        double a = 7, b = 12;
        double avg = (a + b) / 2;
        Console.WriteLine($"a = {a}, b = {b}, середнє арифметичне: {avg}\n");
    }

    // 2. Вивести текст
    static void Task2()
    {
        Console.WriteLine("=== Завдання 2 ===");
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
        Console.WriteLine();
    }

    // 3. Перевірка числа на парність
    static void Task3()
    {
        Console.WriteLine("=== Завдання 3 ===");
        int n = 15;
        Console.WriteLine($"Число: {n}");
        if (n % 2 == 0)
            Console.WriteLine("Число парне.\n");
        else
            Console.WriteLine("Число непарне.\n");
    }

    // 4. Кількість цифр і сума цифр (a < 100)
    static void Task4()
    {
        Console.WriteLine("=== Завдання 4 ===");
        int a = 57;
        int sum = 0, count = 0, temp = a;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
            count++;
        }

        Console.WriteLine($"Число: {a}");
        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}\n");
    }

    // 5. Перевернути число
    static void Task5()
    {
        Console.WriteLine("=== Завдання 5 ===");
        string num = "12345";
        char[] arr = num.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        Console.WriteLine($"Число: {num}");
        Console.WriteLine($"Перевернуте число: {reversed}\n");
    }

    // 6. Сума цифр числа
    static void Task6()
    {
        Console.WriteLine("=== Завдання 6 ===");
        int n = 9876;
        int sum = 0, temp = n;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }

        Console.WriteLine($"Число: {n}");
        Console.WriteLine($"Сума цифр: {sum}\n");
    }
}
