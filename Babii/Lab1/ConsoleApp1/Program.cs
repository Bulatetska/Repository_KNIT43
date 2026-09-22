using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("ЗАВДАННЯ 1");

        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double average = (a + b) / 2;

        Console.WriteLine("Середнє арифметичне: " + average);



        Console.WriteLine();
        Console.WriteLine("ЗАВДАННЯ 2");

        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");



        Console.WriteLine();
        Console.WriteLine("ЗАВДАННЯ 3");

        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("Число парне");
        }
        else
        {
            Console.WriteLine("Число непарне");
        }


        
        Console.WriteLine();
        Console.WriteLine("ЗАВДАННЯ 4");

        Console.Write("Введіть натуральне число (a < 100): ");
        int a4 = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        int sum4 = 0;
        int temp4 = a4;

        while (temp4 > 0)
        {
            int digit = temp4 % 10;
            sum4 = sum4 + digit;
            count = count + 1;
            temp4 = temp4 / 10;
        }

        Console.WriteLine("Кількість цифр: " + count);
        Console.WriteLine("Сума цифр: " + sum4);



        Console.WriteLine();
        Console.WriteLine("ЗАВДАННЯ 5");

        Console.Write("Введіть число: ");
        int number5 = Convert.ToInt32(Console.ReadLine());

        int reverse = 0;
        int temp5 = number5;

        while (temp5 > 0)
        {
            int digit = temp5 % 10;
            reverse = reverse * 10 + digit;
            temp5 = temp5 / 10;
        }

        Console.WriteLine("Число навпаки: " + reverse);



        Console.WriteLine();
        Console.WriteLine("ЗАВДАННЯ 6");

        Console.Write("Введіть число: ");
        int number6 = Convert.ToInt32(Console.ReadLine());

        int sum6 = 0;
        int temp6 = number6;

        while (temp6 > 0)
        {
            int digit = temp6 % 10;
            sum6 = sum6 + digit;
            temp6 = temp6 / 10;
        }

        Console.WriteLine("Сума цифр числа: " + sum6);
    }
}