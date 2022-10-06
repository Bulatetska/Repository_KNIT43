Random rand = new Random();
double[] arr = new double[30];
int pos = 0;
int zero = 0;
for(int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(-50, 50);
    Console.Write(arr[i]+" ");
}
for(int i = 1; i < arr.Length; i++)
{
    if (arr[i] > 0 && arr[i-1]>0)
    {
        pos++;
    }
    if (arr[i] == 0 && arr[i-1]==0)
    {
        zero++;
    }
}
Console.WriteLine("\nDodatni - " + pos + ", zero - " + zero);
