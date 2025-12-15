using System;

class Program
{
    static void Main()
    {
        
        Task1();
    }

    
    static void Task1()
    {
        Console.WriteLine("=== Завдання 7 (Позиція останньої 'і') ===");
        string input = "Привіт, світ!";

        string lowerInput = input.ToLower();

        int lastIndex = lowerInput.LastIndexOf('і');

        Console.WriteLine($"Заданий рядок: \"{input}\"");

        if (lastIndex >= 0)
        {
            Console.WriteLine($"Остання буква 'і' знаходиться на позиції: {lastIndex + 1}\n");
        }
        else
        {
            Console.WriteLine("Буква 'і' не знайдена у рядку.\n");
        }
    }
}