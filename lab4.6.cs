using System;
class Program
{
  static void Main(){
  Console.Write("Size: ");
  int s = Int32.Parse(Console.ReadLine());
  double[] array = new double[s];
  for(int i = 0;i<s;i++){
  	array[i] = double.Parse(Console.ReadLine());
  }
  for(int i = 0;i<s;i++){
  	Console.Write(array[i] + " ");
  }
double sum = 0;
int j = 0;
  while (j < s)
  {
       sum += array[j];
       j++;
  }  
  Console.Write("Sum = " + sum);
}
}
