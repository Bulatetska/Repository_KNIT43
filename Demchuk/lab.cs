using System;
namespace Demchuk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /task1
            Console.Write("Введіть перше число: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Введіть друге число: ");
            double secondNumber = double.Parse(Console.ReadLine());
            double average = (firstNumber + secondNumber) / 2.0;
            Console.WriteLine($"Середнє арифметичне: {average}\n");

            /task2
            Console.WriteLine("To be or not to be");
            Console.WriteLine("\\ Shakespeare \\\n");

            /task3
            Console.Write("Введіть ціле число: ");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine($"Число {number} є парним.\n");
            }
            else
            {
                Console.WriteLine($"Число {number} є непарним.\n");
            }

            /task4
            Console.Write("Введіть натуральне число a (a < 100): ");
            int a = int.Parse(Console.ReadLine());
            if (a <= 0 || a >= 100)
            {
                Console.WriteLine("Помилка: число повинно бути натуральним і меншим за 100.\n");
            }
            else
            {
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
                    int tens = a / 10;
                    int units = a % 10;
                    sum = tens + units;
                }
                Console.WriteLine($"Кількість цифр: {count}");
                Console.WriteLine($"Сума цифр: {sum}\n");
            }

            /task5
            Console.Write("Введіть число: ");
            int inputNum5 = int.Parse(Console.ReadLine());
            int temp5 = Math.Abs(inputNum5);
            int reversedNumber = 0;
            while (temp5 > 0)
            {
                int digit = temp5 % 10;
                reversedNumber = reversedNumber * 10 + digit;
                temp5 /= 10;
            }
            if (inputNum5 < 0)
            {
                reversedNumber = -reversedNumber;
            }
            Console.WriteLine($"Результат: {reversedNumber}\n");

            /task6
            Console.Write("Введіть число: ");
            int inputNum6 = int.Parse(Console.ReadLine());
            int temp6 = Math.Abs(inputNum6);
            int sumOfDigits = 0;
            while (temp6 > 0)
            {
                sumOfDigits += temp6 % 10;
                temp6 /= 10;
            }
            Console.WriteLine($"Сума цифр числа = {sumOfDigits}\n");
        }
    }
}
