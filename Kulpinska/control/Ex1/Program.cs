using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть рядок: ");
        string input = Console.ReadLine()!;

        int lastIndex = input.LastIndexOf('і');

        if (lastIndex != -1)
            Console.WriteLine($"Остання буква 'і' знаходиться на позиції: {lastIndex}");
        else
            Console.WriteLine("Буква 'і' не знайдена у рядку.");
    }
}
