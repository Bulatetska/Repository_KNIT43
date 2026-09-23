using System;

namespace DotNetLab2
{
    class Program
    {
        static void Main()
        {
            //Завдання 1
            Console.WriteLine("Завдання 1: ");
            Console.Write("Введіть перше число: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть друге число: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Середнє арифметичне: {(num1 + num2) / 2}");

            Console.WriteLine();

            //Завдання 2
            Console.WriteLine("Завдання 2: ");
            Console.WriteLine("To be or not to be\n\\ Shakespeare \\");

            Console.WriteLine();

            //Завдання 3
            Console.WriteLine("Завдання 3: ");
            Console.Write("Введіть ціле число: ");
            int parityNum = Convert.ToInt32(Console.ReadLine());
            if (parityNum % 2 == 0)
                Console.WriteLine("Число парне.");
            else
                Console.WriteLine("Число непарне.");

            Console.WriteLine();

            //Завдання 4
            Console.WriteLine("Завдання 4: ");
            Console.Write("Введіть натуральне число до 100: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a > 0 && a < 100)
            {
                int count = a < 10 ? 1 : 2;
                int sum = (a / 10) + (a % 10);
                Console.WriteLine($"Кількість цифр: {count}");
                Console.WriteLine($"Сума цифр: {sum}");
            }
            else
            {
                Console.WriteLine("Число не відповідає умові (a < 100 та a > 0).");
            }

            Console.WriteLine();

            //Завдання 5
            Console.WriteLine("Завдання 5:");
            Console.Write("Введіть число: ");
            string inputNum = Console.ReadLine();
            char[] charArray = inputNum.ToCharArray();
            Array.Reverse(charArray);
            string reversedNum = new string(charArray);
            Console.WriteLine($"Число навпаки: {reversedNum}");

            Console.WriteLine();

            //Завдання 6
            Console.WriteLine("Завдання 6: ");
            Console.Write("Введіть число: ");
            int anyNum = Math.Abs(Convert.ToInt32(Console.ReadLine())); //Math.Abs для захисту від від'ємних
            int sumAny = 0;
            while (anyNum > 0)
            {
                sumAny += anyNum % 10;
                anyNum /= 10;
            }
            Console.WriteLine($"Сума цифр числа: {sumAny}");

            Console.ReadLine();
        }
    }
}