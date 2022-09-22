using System;
{
  Random rand = new Random();
  int N = 0;
  
  
  Console.Write("Массив чисел: ");
  N = Int32.Parse(Console.ReadLine());
  int maxElem = 0, maxElemNumb = 0, indexFirstMax = 0;
  int[] value = new int[N];
  for (int i = 1; i < N; i++) {
    value[i] = rand.Next(-100, 100);
    if (value[i] > maxElem) {
      maxElem = value[i];
      indexFirstMax = i;
    }
  }
  foreach (int i in value) {
    Console.Write(i + "; ");
  if (i == maxElem) {
    maxElemNumb++;
  }
  }
  
  
  Console.WriteLine("\nКількість найілього елементу в заданному масиві: " + maxElemNumb);
  Console.WriteLine("Порядковий номер найбілього елементу: " + indexFirstMax);
  Console.ReadLine();
}
