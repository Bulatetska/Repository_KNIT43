
using System;
{
	// Вводимо коефіцієнти ТУТ
	double a = 1, b = 4, c = 3;

	Console.WriteLine(a + "x^2 + " + b + "x + " + c + " = 0;");
	double D = b*b - 4*a*c;
	double x1, x2, x;
	if (D > 0) {
		Console.WriteLine("D > 0 (D = " + D + "), so we have 2 solutions:");
		D = Math.Sqrt(D);
		x1 = (-b + D) / (2*a);
		x2 = (-b - D) / (2*a);
		Console.WriteLine("x1 = " + x1 + ",\nx2 = " + x2 + ".");
	}
	else if (D == 0) {
		Console.WriteLine("D = 0, so we have 1 solution:");
		x = -b / (2*a);
		Console.WriteLine("x = " + x + ".");
	}
	else {
		Console.WriteLine("D < 0 (D = " + D + "); No solutions.");
	}
	Console.ReadLine();
}