using System;
{
	// ������� ����������� ���
	double[] triangle = {12, 5, 13};
	// ���������� ������
	Array.Sort(triangle);
	Console.WriteLine("Triangle: " + triangle[0] + ", " + triangle[1] + ", " + triangle[2] + ".");
	if (triangle[0] + triangle[1] > triangle[2]) {
		double p = (triangle[0] + triangle[1] + triangle[2])/2;
		double S = Math.Sqrt(p * (p - triangle[0]) * (p - triangle[1]) * (p - triangle[2]));
		Console.WriteLine("S = " + S + ".");
	}
	else {
		Console.WriteLine("Triangle doesn't exist.");
	}
	Console.ReadLine();
}
