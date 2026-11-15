using System;
using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Лабораторна робота: 6 завдань на C#");
    Console.WriteLine("1. Середнє арифметичне двох чисел");
    Console.WriteLine("2. Виведення тексту Shakespeare");
    Console.WriteLine("3. Перевірка числа на парність");
    Console.WriteLine("4. Кількість і сума цифр натурального числа до 100");
    Console.WriteLine("5. Перевернути число");
    Console.WriteLine("6. Сума цифр числа");
    Console.WriteLine("0. Вихід");
    Console.Write("Оберіть завдання: ");

    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
        {
            Console.Write("Введіть перше число: ");
            bool firstValid = TryReadDouble(Console.ReadLine(), out double first);
            Console.Write("Введіть друге число: ");
            bool secondValid = TryReadDouble(Console.ReadLine(), out double second);

            if (!firstValid || !secondValid)
            {
                Console.WriteLine("Помилка: потрібно ввести два числа.");
                break;
            }

            double average = (first + second) / 2;
            Console.WriteLine($"Середнє арифметичне: {average}");
            break;
        }
        case "2":
        {
            Console.WriteLine("To be or not to be");
            Console.WriteLine("\\ Shakespeare \\");
            break;
        }
        case "3":
        {
            Console.Write("Введіть ціле число: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Помилка: введіть ціле число.");
                break;
            }

            if (number % 2 == 0)
                Console.WriteLine("Число парне.");
            else
                Console.WriteLine("Число непарне.");
            break;
        }
        case "4":
        {
            Console.Write("Введіть натуральне число (1–99): ");
            if (!int.TryParse(Console.ReadLine(), out int number) || number < 1 || number >= 100)
            {
                Console.WriteLine("Помилка: число має бути від 1 до 99.");
                break;
            }

            int digitCount = number < 10 ? 1 : 2;
            int digitSum = number / 10 + number % 10;
            Console.WriteLine($"Кількість цифр: {digitCount}");
            Console.WriteLine($"Сума цифр: {digitSum}");
            break;
        }
        case "5":
        {
            Console.Write("Введіть ціле число: ");
            string input = (Console.ReadLine() ?? "").Trim();
            if (!long.TryParse(input, out long number))
            {
                Console.WriteLine("Помилка: введіть ціле число.");
                break;
            }

            bool isNegative = number < 0;
            string digits = input.TrimStart('+', '-');
            string reversed = "";
            for (int i = digits.Length - 1; i >= 0; i--)
                reversed += digits[i];

            reversed = reversed.TrimStart('0');
            if (reversed.Length == 0)
                reversed = "0";
            if (isNegative && reversed != "0")
                reversed = "-" + reversed;

            Console.WriteLine($"Число навпаки: {reversed}");
            break;
        }
        case "6":
        {
            Console.Write("Введіть ціле число: ");
            string input = (Console.ReadLine() ?? "").Trim();
            if (!long.TryParse(input, out _))
            {
                Console.WriteLine("Помилка: введіть ціле число.");
                break;
            }

            int sum = 0;
            foreach (char digit in input)
            {
                if (char.IsDigit(digit))
                    sum += digit - '0';
            }

            Console.WriteLine($"Сума цифр числа: {sum}");
            break;
        }
        case "0":
            Console.WriteLine("Завершення роботи.");
            return;
        default:
            Console.WriteLine("Немає такого пункту меню. Оберіть число від 0 до 6.");
            break;
    }
}

static bool TryReadDouble(string? text, out double number)
{
    text = text?.Replace(',', '.');
    return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out number);
}
