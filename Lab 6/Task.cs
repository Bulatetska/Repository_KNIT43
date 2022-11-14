using System;

class program {
	static void Main() {
		double[,] mass = new double[4, 2];
		Initialization(mass);
		Console.ReadLine();
	}
	static void Initialization(double[,] mass) {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 2; j++) {
				if (j == 0) {
					Console.Write($"Введiть координати {i}-ї точки:\nx: ");
					mass[i, j] = Convert.ToDouble(Console.ReadLine());
				}
				else {
					Console.Write("y: ");
					mass[i, j] = Convert.ToDouble(Console.ReadLine());
				}
			}
		}
		Console.WriteLine();
		findLength(mass);
	}
	static void findLength(double[,] mass) {
		double[] max = {0, 0};
		double length = 0;
		Console.WriteLine($"\nНайкоротша вiдстань мiж точками:");
		for (int i = 0; i < 4; i++) {
			length = Math.Sqrt(Math.Pow(mass[i, 0] - mass[((i + 1) % 4), 0], 2) + Math.Pow(mass[i, 1] - mass[((i + 1) % 4), 1], 2));
			if (i == 0) {
				max[1] = length;
			}
			if (length <= max[1]) {
				max[0] = i;
				max[1] = length;
				Console.WriteLine($"{i} та {(i + 1)}");
			}
		}
	}
}