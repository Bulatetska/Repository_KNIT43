using System;

class Task3
{
    public static void Run()
    {
        Console.Write("Число: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n % 2 == 0)
            Console.WriteLine("Парне");
        else
            Console.WriteLine("Непарне");
    }
}