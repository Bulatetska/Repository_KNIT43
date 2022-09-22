using System;
{
  Random rand = new Random();
  int N = 0;
  double summ = 0;
  Console.Write("Введіть розрядність одновимірного масива :");
  
  N = Int32.Parse(Console.ReadLine());
  double[] value = new double[N];
  
  
  for (int i = 0; i < N; i++) {
    value[i] = rand.NextDouble();
    Console.WriteLine(value[i] + " ");
    summ += value[i];
  }
  
  
  Console.WriteLine("Сума елементів: " + summ);
  Console.ReadLine();
}
