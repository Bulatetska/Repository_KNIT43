using System;
{
	// Variant 24
	//double A = -2100, C = 0.001;
	//int I = 444;
	//bool L = true;
	//string N = "Vitaliiovych";
	Console.WriteLine("Variant 24");
	Console.Write("Input A: "); double A = Convert.ToDouble(Console.ReadLine());
	Console.Write("Input I: "); int I = Convert.ToInt32(Console.ReadLine());
	Console.Write("Input C: "); double C = Convert.ToDouble(Console.ReadLine());
	Console.Write("Input L: "); bool L = Convert.ToBoolean(Console.ReadLine());
	Console.Write("Input N: "); string N = Console.ReadLine();
	Console.WriteLine("A = {0:0.0E-0}; I = {1}; C = {2:0E+0}; L = {3}; N = {4}", A, I, C, L, N);
	Console.ReadLine();
}