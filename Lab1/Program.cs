using System;

class Program
{
    static void Main()
    {
        // 1. Середнє арифметичне двох чисел
        Console.WriteLine("1. Обчислення середнього арифметичного двох чисел:");
        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());
        double avg = (a + b) / 2;
        Console.WriteLine("Середнє арифметичне = " + avg);
        Console.WriteLine();

        // 2. Виведення тексту
        Console.WriteLine("2. Виведення тексту:");
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
        Console.WriteLine();

        // 3. Перевірка числа на парність
        Console.WriteLine("3. Перевірка числа на парність:");
        Console.Write("Введіть число: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num % 2 == 0)
            Console.WriteLine("Число парне");
        else
            Console.WriteLine("Число непарне");
        Console.WriteLine();

        // 4. Кількість і сума цифр числа (a < 100)
        Console.WriteLine("4. Кількість і сума цифр числа (a < 100):");
        Console.Write("Введіть число (менше 100): ");
        int n = Convert.ToInt32(Console.ReadLine());
        int count = n.ToString().Length;
        int temp = n;
        int sum = 0;
        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }
        Console.WriteLine("Кількість цифр: " + count);
        Console.WriteLine("Сума цифр: " + sum);
        Console.WriteLine();

        // 5. Перевернути число
        Console.WriteLine("5. Перевернути число:");
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int reversed = 0;
        int t = number;
        while (t > 0)
        {
            int digit = t % 10;
            reversed = reversed * 10 + digit;
            t /= 10;
        }
        Console.WriteLine("Перевернуте число: " + reversed);
        Console.WriteLine();

        // 6. Сума цифр числа
        Console.WriteLine("6. Сума цифр числа:");
        Console.Write("Введіть число: ");
        int x = Convert.ToInt32(Console.ReadLine());
        int s = 0;
        int k = x;
        while (k > 0)
        {
            s += k % 10;
            k /= 10;
        }
        Console.WriteLine("Сума цифр числа = " + s);
    }
}
