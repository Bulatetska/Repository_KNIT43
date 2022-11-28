using System;
{
  for (int i = 1; i <= 100; i++) {
    if (i % 3 == 0 && i % 5 == 0) {
      Console.WriteLine(i + " : % 3 and % 5");
    }
    else if (i % 3 == 0) {
      Console.WriteLine(i + " : % 3");
    }
    else if (i % 5 == 0) {
      Console.WriteLine(i + " : % 5");
    }
    else {
      Console.WriteLine(i);
    }
  }
  Console.ReadLine();
}
