Random rand = new Random();
int n = 4, max = 0;
int[,] arr = new int[n,n];
for(int i = 0; i < n; i++)
{
    for(int j = 0; j < n; j++)
    {
        arr[i, j] = rand.Next(0, 20);
        if(arr[i, j] > max)
        {
            max = arr[i, j];
        }
        if (arr[i, j] < 10)
        {
            Console.Write(" ");
        }
        Console.Write(arr[i, j]+" ");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine();

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (arr[i, j] == max)
        {
            arr[i, j] = 0;
        }
        if (arr[i, j] < 10)
        {
            Console.Write(" ");
        }
        Console.Write(arr[i, j]+" ");
    }
    Console.WriteLine();
}