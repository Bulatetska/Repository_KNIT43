using System;
using System.Text;

class Program
{
    static void Average()
    {
        Console.Write("Введіть перше число, щоб обчислити середнє арифметичне двох чисел: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double aver = (a+b)/2;
        Console.WriteLine($"Середнє арифметичне = {aver}\n");
    }

    static void Print()
    {
        Console.WriteLine("""
        To be or not to be
        \ Shakespeare \

        """);
    }

    static void CheckEven()
    {
        Console.Write("Введіть натуральне число, щоб перевірити на парність: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n%2 == 0)
            Console.WriteLine("Число парне\n");
        else
            Console.WriteLine("Число непарне\n");
    }

    static void Info()
    {
        Console.Write("Введіть натуральне число (a < 100), щоб  вивести на екран кількість цифр в цьому числі і суму цих цифр: ");
        int a = Convert.ToInt32(Console.ReadLine());

        int count = a.ToString().Length;

        int sum = 0;
        int temp = a;

        while (temp > 0)
        {
            sum += temp%10;
            temp /= 10;
        }

        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}\n");
    }

    static void Reverse()
    {
        Console.Write("Введіть число, щоб перевернути його: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int reversed=0;
        int temp = num;

        while (temp > 0)
        {
            reversed = reversed * 10 + temp % 10;
            temp /= 10;
        }

        Console.WriteLine($"Перевернуте число: {reversed}\n");
    }


    static void SumOfNumbers()
    {
        Console.Write("Введіть число, щоб обрахувати суму його цифр.: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int sum=0;
        int temp=num;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }
        Console.WriteLine($"Сума цифр = {sum}\n");
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Average();
        Print();
        CheckEven();
        Info();
        Reverse();
        SumOfNumbers();
    }
}