using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Середнє арифметичне двох чисел
            Console.WriteLine("Введіть перше число:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть друге число:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            double avg = (num1 + num2) / 2;
            Console.WriteLine($"Середнє арифметичне: {avg}");

            // 2. Вивести текст
            Console.WriteLine("To be or not to be \\ Shakespeare \\");

            // 3. Перевірка парності
            Console.WriteLine("Введіть число для перевірки на парність:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n % 2 == 0)
                Console.WriteLine("Число парне");
            else
                Console.WriteLine("Число непарне");

            // 4. Кількість цифр і сума цифр
            Console.WriteLine("Введіть натуральне число a (a < 100):");
            int a = Convert.ToInt32(Console.ReadLine());
            int count = a.ToString().Length;
            int sum = 0;
            foreach (char c in a.ToString())
            {
                sum += c - '0';
            }
            Console.WriteLine($"Кількість цифр: {count}, Сума цифр: {sum}");

             // 5.Перевернути число
            Console.WriteLine("Введіть число для перевертання:");
            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);
            Console.WriteLine($"Перевернуте число: {reversed}");

            // 6. Сума цифр числа
            Console.WriteLine("Введіть число для обчислення суми цифр:");
            int num = Convert.ToInt32(Console.ReadLine());
            int sum2 = 0;
            while (num > 0)
            {
                sum2 += num % 10;
                num /= 10;
            }
            Console.WriteLine($"Сума цифр: {sum2}");

            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
