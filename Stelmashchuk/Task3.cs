using System;

class Task3
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n % 2 == 0)
        {
            Console.WriteLine("Число парне");
        }
        else
        {
            Console.WriteLine("Число непарне");
        }
    }
}
