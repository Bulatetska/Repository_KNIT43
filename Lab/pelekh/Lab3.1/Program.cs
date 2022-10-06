{
    for (int i = 1; i <= 100; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine(i + " кратне 3 і 5");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine(i + " кратне 3");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine(i + " кратне 5");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
    Console.ReadLine();
}