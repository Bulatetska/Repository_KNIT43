using System;
{
  Random rand = new Random();
  
  //ініціалізація розмірності
  const int h = 6, w = 9; 
  
  int min = 0, max = 0;
  Console.Write("Введіть мінімальне значення : ");
  min = Int32.Parse(Console.ReadLine());
  Console.Write("Введіть максимальне значення : ");
  max = Int32.Parse(Console.ReadLine());
  int height = 0, summ = 0;
  double elMax = 0;
  int[,] value = new int[h, w];
  string dash = "*****";
  for (int i = 0; i < w; i++) {
    dash += "*****";
  }
  Console.WriteLine(" " + dash);
  for (int i = 0; i < h; i++) {
    Console.Write("  line " + i + " ");
    for (int j = 0; j < w; j++) {
      value[i, j] = rand.Next(min, max);
      if (value[i, j] < 10) {
        Console.Write(" |  " + value[i, j]);
      }
      else {
        Console.Write(" | " + value[i, j]);
      }
      if (elMax < value[i, j]) {
        elMax = value[i, j];
        height = i;
      }
    }
    Console.WriteLine(" |\n " + dash);
  }
  for (int i = 0; i < w; i++) {
    summ += value[height, i];
  }
  Console.WriteLine("\nСума елементів з найбільшим елементом: " + summ);
  Console.ReadLine();
}
