Random rand = new Random();
int size = 7;
int sum = 0;
int[,] arr = new int[size,size];
for(int i = 0; i < arr.GetLength(0); i++)
{
    for(int j = 0; j < arr.GetLength(1); j++)
    {
        arr[i, j] = rand.Next(-50, 50);
        Console.Write((arr[i,j]<10&&arr[i,j]>-10?"  ":" ")+arr[i, j]);
        sum += arr[i, j];
    }
    Console.WriteLine();
}
int avg = sum / (size * size);
Console.WriteLine(avg+"\n");
for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        if(arr[i, j] > avg)
        {
            arr[i, j] = 1;
        }
        if(arr[i, j] < avg)
        {
            arr[i, j] = -1;
        }
        Console.Write((arr[i, j] < 0 ? " " : "  ") + arr[i, j]);
    }
    Console.WriteLine();
}
