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
	double maxValue = 0;
	double[,] value = new double[N, N];
	string dash = "-----";
	for (int i = 1; i < N; i++) {
		dash += "-----";
	}
	Console.WriteLine(" -" + dash);
	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++) {
			value[i, j] = rand.Next(min, max);
			if (value[i, j] < 10) {
				Console.Write(" |  " + value[i, j]);
			}
			else {
				Console.Write(" | " + value[i, j]);
			}
			if (value[i, j] > maxValue) {
				maxValue = value[i, j];
			}
		}
		Console.WriteLine(" |\n -" + dash);
	}
	Console.WriteLine("\nMax value is " + maxValue + "\nNow " + maxValue + " == 0\n");
	Console.WriteLine(" -" + dash);
	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++) {
			if (value[i, j] == maxValue) {
				value[i, j] = 0;
			}
			if (value[i, j] < 10) {
				Console.Write(" |  " + value[i, j]);
			}
			else {
				Console.Write(" | " + value[i, j]);
			}
		}
		Console.WriteLine(" |\n -" + dash);
	}
	Console.ReadLine();
}