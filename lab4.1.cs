  using System;
  class Program
  {
  static void Main(){
  Console.Write("Size: ");
  int s = Int32.Parse(Console.ReadLine());
  int[] array = new int[s];
  int maxElem= array[0], countMaxElement = 0, indexFirstMax=0;
  
  for (int i = 0; i < s; i++)
  {
      array[i] = Int32.Parse(Console.ReadLine());
      if (maxElem < array[i])
      {
         maxElem = array[i];
      }
  }
  bool t =true;
  for(int i=0;i < s; i++) {
    Console.Write(array[i] + ", ");
  if (array[i] == maxElem) {
    countMaxElement++;
    if(t){
    indexFirstMax = i +1;
    t= false;
    }
  }
  }
  
  Console.WriteLine("\nК-сть найбільшого елементу в заданному масиві: " + countMaxElement);
  Console.WriteLine("Порядковий номер найбільшого елементу: " + indexFirstMax);
  Console.ReadLine();
  }
  }
