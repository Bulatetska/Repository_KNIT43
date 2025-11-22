using System;

class Program
{
    static void Main()
    {
        Console.Write("Choose a task (1–4): ");
        int choice = int.Parse(Console.ReadLine()!);

        switch (choice)
        {
            case 1: Task1.Run(); break;
            case 2: Task2.Run(); break;
            case 3: Task3.Run(); break;
            case 4: Task4.Run(); break;
            default: Console.WriteLine("Wrong choise"); break;
        }
    }
}

class Task1
{
    public static void Run()
    {
        Console.Write("Enter first number: ");
        string s1 = Console.ReadLine();

        Console.Write("Enter second number: ");
        string s2 = Console.ReadLine();

        if (!double.TryParse(s1, out double a) || !double.TryParse(s2, out double b))
        {
            Console.WriteLine("Invalid input. Enter numbers in the format, for example: 3.5 or 2");
            return;
        }

        double average = (a + b) / 2.0;
        Console.WriteLine($"Arithmetic mean: {average}");
    }
}

class Task2
{
    public static void Run()
    {
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
    }
}

class Task3
{
    public static void Run()
    {
        Console.Write("Enter an integer number: ");
        string s = Console.ReadLine();

        if (!int.TryParse(s, out int n))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (n % 2 == 0)
            Console.WriteLine("Number is even.");
        else
            Console.WriteLine("Number is odd.");
    }
}

class Task4
{
    public static void Run()
    {
        Console.Write("Enter a natural number a (a < 100): ");
        string s = Console.ReadLine();

        if (!int.TryParse(s, out int a) || a < 0 || a >= 100)
        {
            Console.WriteLine("The number must be a natural number and less than 100.");
            return;
        }

        int sum = 0;
        int count = 0;
        int temp = a;

        if (temp == 0) count = 1;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
            count++;
        }

        Console.WriteLine($"Number: {a}");
        Console.WriteLine($"Number of digits: {count}");
        Console.WriteLine($"Sum of digits: {sum}");
    }
}

