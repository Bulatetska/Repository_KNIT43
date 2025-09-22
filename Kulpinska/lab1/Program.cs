using System;

class Program
{
    static void AverageTwoNumbers()
    {
        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double avg = (a + b) / 2;
        Console.WriteLine($"Середнє арифметичне = {avg}\n");
    }

    static void PrintText()
    {
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\\n");
    }

    static void CheckEven()
    {
        Console.Write("Введіть число: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n % 2 == 0)
            Console.WriteLine("Число парне\n");
        else
            Console.WriteLine("Число непарне\n");
    }

    static void DigitsInfo()
    {
        Console.Write("Введіть число (a < 100): ");
        int a = Convert.ToInt32(Console.ReadLine());

        int count = a.ToString().Length;
        int sum = 0;
        int temp = a;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }

        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}\n");
    }

    static void ReverseNumber()
    {
        Console.Write("Введіть число: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int reversed = 0;
        int temp = num;

        while (temp > 0)
        {
            int digit = temp % 10;
            reversed = reversed * 10 + digit;
            temp /= 10;
        }

        Console.WriteLine($"Перевернуте число: {reversed}\n");
    }


    static void SumOfDigits()
    {
        Console.Write("Введіть число: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int temp = num;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }

        Console.WriteLine($"Сума цифр числа = {sum}\n");
    }

    static void Main(string[] args)
    {
        AverageTwoNumbers();
        PrintText();
        CheckEven();
        DigitsInfo();
        ReverseNumber();
        SumOfDigits();
    }
}
