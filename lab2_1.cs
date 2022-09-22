{
  bool boolVariable = true;
  if (boolVariable) {
    System.Console.WriteLine("boolVariable = true; --- істина!");
  }
  else {
    System.Console.WriteLine("boolVariable = false; хибно!");
  }
  System.Console.WriteLine();

  boolVariable = false;
  if (boolVariable) {
    System.Console.WriteLine("boolVariable = true; --- істина!");
  }
  else {
    System.Console.WriteLine("boolVariable = false; хибно!");
  }
  System.Console.WriteLine();

  boolVariable = 2 < 4;
  if (boolVariable) {
    System.Console.WriteLine("boolVariable = 2 < 4; --- істина!");
  }
  else {
    System.Console.WriteLine("boolVariable = 2 < 4; хибно!");
  }
  System.Console.WriteLine();

  if (10 != 100) {
    System.Console.WriteLine("10 != 100 ! різні числа!");
  }
  System.Console.WriteLine();
  System.Console.ReadLine();
}
