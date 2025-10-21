using System;

namespace Lab_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Перше завдання");
            Console.WriteLine("Введіть перше число:");
            float a = float.Parse(Console.ReadLine());

            Console.WriteLine("Введіть друге число:");
            float b = float.Parse(Console.ReadLine());

            float c = (a + b) / 2;

            Console.WriteLine("Середнє арефметичне: "+c);

            Console.WriteLine("\n Друге завдання");

            Console.WriteLine("To be or not to be\n");
            Console.WriteLine("\\ Shakespeare \\ ");

            Console.WriteLine("\nТретє завдання");
            Console.WriteLine("Введіть число яке буде перевірятись на парність:");
            float p = float.Parse(Console.ReadLine());

            if (p % 2 == 0)
                Console.WriteLine("Число парне");
            else
                    Console.WriteLine("Число не парне");


            Console.WriteLine("\nЧетверте завдання:");
            Console.Write("Введіть число < 100: ");
            int j = int.Parse(Console.ReadLine());

            int sum = 0;
            int count = 0;
            int temp = j;

            while (temp > 0)
            {
                sum += temp % 10;
                temp /= 10;
                count++;
            }

            Console.WriteLine("Кількість цифр: " + count);
            Console.WriteLine("Сума цифр: " + sum);
           


            Console.WriteLine("П'яте завдання: ");
            Console.Write("Введіть число яке буде перевернутим: ");
            int n = int.Parse(Console.ReadLine());
            int reversed = 0;

            while (n > 0)
            {
                int digit = n % 10;
                reversed = reversed * 10 + digit;
                n /= 10;
            }

            Console.WriteLine("Перевернуте число: " + reversed);


            Console.WriteLine("Шосте завдання: ");
            Console.Write("Введіть число: ");
            int o = int.Parse(Console.ReadLine());
            int summ = 0;

            while (o > 0)
            {
                summ += o % 10;
                o /= 10;
            }

            Console.WriteLine("Сума цифр числа: " + summ);
            Console.ReadLine();
        }
    }
}
