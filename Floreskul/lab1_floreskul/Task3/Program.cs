using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("Число парне");
        }
        else
        {
            Console.WriteLine("Число непарне");
        }
    }
}
