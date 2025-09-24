using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Лабораторна робота 1: Умовні оператори, цикли. Робота з рядками.");
        Console.WriteLine("Оберіть завдання (1-6) або 0 для виходу:");
        
        while (true)
        {
            Console.WriteLine("\n1. Середнє арифметичне двох чисел");
            Console.WriteLine("2. Вивід тексту");
            Console.WriteLine("3. Перевірка числа на парність");
            Console.WriteLine("4. Кількість цифр та їх сума (для числа < 100)");
            Console.WriteLine("5. Перевернути число");
            Console.WriteLine("6. Сума цифр числа");
            Console.WriteLine("0. Вийти");
            Console.Write("Ваш вибір: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    Task5();
                    break;
                case "6":
                    Task6();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
    
    // Завдання 1: Середнє арифметичне двох чисел
    static void Task1()
    {
        Console.WriteLine("\n--- Завдання 1 ---");
        Console.Write("Введіть перше число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Введіть друге число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());
        
        double average = (num1 + num2) / 2;
        Console.WriteLine($"Середнє арифметичне: {average}");
    }
    
    // Завдання 2: Вивід тексту
    static void Task2()
    {
        Console.WriteLine("\n--- Завдання 2 ---");
        Console.WriteLine("To be or not to be");
        Console.WriteLine("\\ Shakespeare \\");
    }
    
    // Завдання 3: Перевірка числа на парність
    static void Task3()
    {
        Console.WriteLine("\n--- Завдання 3 ---");
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        if (number % 2 == 0)
        {
            Console.WriteLine($"Число {number} є парним.");
        }
        else
        {
            Console.WriteLine($"Число {number} є непарним.");
        }
    }
    
    // Завдання 4: Кількість цифр та їх сума (для числа < 100)
    static void Task4()
    {
        Console.WriteLine("\n--- Завдання 4 ---");
        Console.Write("Введіть натуральне число (менше 100): ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        if (number < 0 || number >= 100)
        {
            Console.WriteLine("Помилка! Число має бути натуральним і меншим за 100.");
            return;
        }
        
        if (number < 10)
        {
            Console.WriteLine("Кількість цифр: 1");
            Console.WriteLine($"Сума цифр: {number}");
        }
        else
        {
            int digit1 = number / 10;
            int digit2 = number % 10;
            int sum = digit1 + digit2;
            
            Console.WriteLine("Кількість цифр: 2");
            Console.WriteLine($"Сума цифр: {sum}");
        }
    }
    
    // Завдання 5: Перевернути число
    static void Task5()
    {
        Console.WriteLine("\n--- Завдання 5 ---");
        Console.Write("Введіть число: ");
        string input = Console.ReadLine();
        
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        
        Console.WriteLine($"Перевернуте число: {reversed}");
    }
    
    // Завдання 6: Сума цифр числа
    static void Task6()
    {
        Console.WriteLine("\n--- Завдання 6 ---");
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int originalNumber = number;
        int sum = 0;
        
        while (number > 0)
        {
            int digit = number % 10;
            sum += digit;
            number /= 10;
        }
        
        Console.WriteLine($"Сума цифр числа {originalNumber} дорівнює {sum}");
    }
}