{
    Random rand = new Random();
    int[] value = new int[30];
    for (int i = 0; i < 30; i++)
    {
        value[i] = rand.Next(0, 20);
    }
    int max = 0, maxCount = 0, maxPos = 0;
    for (int i = 0; i < 30; i++)
    {
        if (value[i] > max)
        {
            max = value[i];
            maxPos = i;
        }
    }
    foreach (int i in value)
    {
        Console.Write(i + ",");
        if (i == max)
        {
            maxCount++;
        }
    }


    Console.WriteLine("\nMax - " + max + ", " + maxCount + " раз.");
    Console.WriteLine("Позиція max - " + maxPos);
}