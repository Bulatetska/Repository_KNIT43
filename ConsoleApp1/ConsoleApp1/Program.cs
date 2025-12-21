using System;

class Program
{
    static void Main()
    {
        while (true)
        {
    
            Console.WriteLine("1. Обчислити середнє арифметичне двох чисел");
            Console.WriteLine("2. Вивести текст");
            Console.WriteLine("3. Перевірити число на парність");
            Console.WriteLine("4. Порахувати кількість і суму цифр (a < 100)");
            Console.WriteLine("5. Перевернути число");
            Console.WriteLine("6. Сума цифр числа");
            Console.Write("Виберіть номер задачі: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некоректний вибір! Спробуйте ще раз.");
                continue;
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
               
            }
        }
    }

    // 1. Середнє арифметичне
    static void Task1()
    {
        Console.Write("Введіть перше число: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть друге число: ");
        double b = Convert.ToDouble(Console.ReadLine());

        double average = (a + b) / 2;
        Console.WriteLine($"Середнє арифметичне: {average}");
    }

    // 2. Вивести текст
    static void Task2()
    {
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
    }

    // 3. Перевірка на парність
    static void Task3()
    {
        Console.Write("Введіть число: ");
        int num = Convert.ToInt32(Console.ReadLine());

        if (num % 2 == 0)
            Console.WriteLine("Число парне");
        else
            Console.WriteLine("Число непарне");
    }

    // 4. Кількість і сума цифр числа
    static void Task4()
    {
        Console.Write("Введіть натуральне число (a < 100): ");
        int a = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        int count = 0;
        int temp = a;

        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
            count++;
        }

        Console.WriteLine($"Кількість цифр: {count}");
        Console.WriteLine($"Сума цифр: {sum}");
    }

    // 5. Перевернути число
    static void Task5()
    {
        Console.Write("Введіть число: ");
        int num = Convert.ToInt32(Console.ReadLine());
        int reversed = 0;

        while (num > 0)
        {
            int digit = num % 10;
            reversed = reversed * 10 + digit;
            num /= 10;
        }

        Console.WriteLine($"Перевернуте число: {reversed}");
    }

    // 6. Сума цифр числа
    static void Task6()
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

        Console.WriteLine($"Сума цифр числа: {sum}");
    }
}
