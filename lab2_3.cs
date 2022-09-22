using System;
{
  double[] triangle = {69, 90, 120}; //сторони заданного трикутника
  Array.Sort(triangle);
  Console.WriteLine("Строни трикутника : " + triangle[0] + ", " + triangle[1] + ", " + triangle[2] + ".");
  
  if (triangle[0] + triangle[1] > triangle[2]) {
    double p = (triangle[0] + triangle[1] + triangle[2])/2;
    double S = Math.Sqrt(p * (p - triangle[0]) * (p - triangle[1]) * (p - triangle[2]));
    Console.WriteLine("Площа = " + S + ".");
  }
  else {
    Console.WriteLine("Трикутник не існує!");
  }
  Console.ReadLine();
}
