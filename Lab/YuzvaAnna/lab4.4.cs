using System;
{
	Random rand = new Random();
	int h = 0, w = 0, min = 0, max = 0;
	Console.Write("Enter the dimension HxW matrix.\nH = ");
	h = Int32.Parse(Console.ReadLine());
	Console.Write("W = ");
	w = Int32.Parse(Console.ReadLine());
	Console.Write("Enter min number: ");
	min = Int32.Parse(Console.ReadLine());
	Console.Write("Enter max number: ");
	max = Int32.Parse(Console.ReadLine());
	double average = 0;
	int[,] value = new int[h, w];
	string dash = "-----";
	for (int i = 1; i < w; i++) {
		dash += "-----";
	}
	Console.WriteLine(" -" + dash);
	for (int i = 0; i < h; i++) {
		for (int j = 0; j < w; j++) {
			value[i, j] = rand.Next(min, max);
			value[i, j] = rand.Next(min, max);
			if (value[i, j] < 10) {
				Console.Write(" |  " + value[i, j]);
			}
			else {
				Console.Write(" | " + value[i, j]);
			}
			average += value[i, j];
		}
		Console.WriteLine(" |\n -" + dash);
	}
	average /= h * w;
	Console.WriteLine("Average is " + average);
	Console.WriteLine(" -" + dash);
	for (int i = 0; i < h; i++) {
		for (int j = 0; j < w; j++) {
			if (value[i, j] < average) {
				value[i, j] = -1;
				Console.Write(" | " + value[i, j]);
			}
			else if(value[i, j] > average) {
				value[i, j] = 1;
				Console.Write(" |  " + value[i, j]);
			}
		}
		Console.WriteLine(" |\n -" + dash);
	}
	Console.ReadLine();
}