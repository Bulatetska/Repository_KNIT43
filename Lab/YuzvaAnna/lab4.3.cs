using System;
{
	Random rand = new Random();
	int N = 0, min = 0, max = 0;
	Console.Write("Enter the dimension NxN matrix: ");
	N = Int32.Parse(Console.ReadLine());
	Console.Write("Enter min number: ");
	min = Int32.Parse(Console.ReadLine());
	Console.Write("Enter max number: ");
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
	Console.WriteLine(pos + " - positive values is near;\n" + zero + " - null values is near.");
	Console.ReadLine();
}