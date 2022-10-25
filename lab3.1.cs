using System;
class Program
{
    static void Main()
    {
     for (int i = 1; i <= 100; i++) {
      if (i % 3 == 0 && i % 5 == 0) {
      Console.WriteLine(" : % 3 and % 5");
    }
    else if (i % 3 == 0) {
      Console.WriteLine(" : % 3");
    }
    else if (i % 5 == 0) {
      Console.WriteLine(" : % 5");
    }
    else {
      Console.WriteLine(i);
    }
    }
   Console.ReadLine();
    }
}    
