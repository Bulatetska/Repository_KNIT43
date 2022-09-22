using System;
{
  Random rand = new Random();
  int N = 0, min = 0, max = 0;
  Console.Write("Потужність послідовності дійсних чисел: ");
  N = Int32.Parse(Console.ReadLine());
  Console.Write("Введіть мінімальне число: ");
  min = Int32.Parse(Console.ReadLine());
  Console.Write("Введіть максимальне число: ");
  max = Int32.Parse(Console.ReadLine());
  
  
  int pos = 0, zero = 0;
  double[] value = new double[N];
  for (int i = 0; i < N; i++) {
    value[i] = rand.Next(min, max);
    Console.Write(value[i] + " ");
    if (i > 0 && value[i] > 0 && value[i - 1] > 0) {
      pos++;
    }
    else if (i > 0 && value[i] == 0 && value[i - 1] == 0) {
      zero++;
    }
  }
  Console.WriteLine();
  Console.WriteLine(pos + " - кількість сусідсв двох додатніх чисел;\n" + zero + " - кількість сусідсв двох нульових елементів.");
  Console.ReadLine();
}
