using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("     ЛАБОРАТОРНА РОБОТА");
            Console.WriteLine("==============================");
            Console.WriteLine("1 - Завдання 1");
            Console.WriteLine("2 - Завдання 2");
            Console.WriteLine("3 - Завдання 3");
            Console.WriteLine("4 - Завдання 4");
            Console.WriteLine("5 - Завдання 5");
            Console.WriteLine("6 - Завдання 6");
            Console.WriteLine("7 - Запустити всі завдання");
            Console.WriteLine("0 - Вихід");
            Console.WriteLine("==============================");

            Console.Write("Виберіть завдання: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task3_1.Run();
                    break;

                case "2":
                    Task3_2.Run();
                    break;

                case "3":
                    Task3_3.Run();
                    break;

                case "4":
                    Task3_4.Run();
                    break;

                case "5":
                    Task3_5.Run();
                    break;

                case "6":
                    Task3_6.Run();
                    break;

                case "7":
                    Task3_1.Run();
                    Task3_2.Run();
                    Task3_3.Run();
                    Task3_4.Run();
                    Task3_5.Run();
                    Task3_6.Run();
                    break;

                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;

                default:
                    Console.WriteLine(
                        "Помилка. Введіть число від 0 до 7."
                    );
                    break;
            }
        }
    }
}