using System;

public class Quadrangle {
	public static void MainQuadrangle() {
		Console.Clear();
		double Ax, Ay, Bx, By, Cx, Cy, Dx, Dy;
		Console.WriteLine("Введiть координати вершин чотирикутника:\nТочка A:");
		Ax = Convert.ToDouble(Console.ReadLine());
		Ay = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Точка B:");
		Bx = Convert.ToDouble(Console.ReadLine());
		By = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Точка C:");
		Cx = Convert.ToDouble(Console.ReadLine());
		Cy = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Точка D:");
		Dx = Convert.ToDouble(Console.ReadLine());
		Dy = Convert.ToDouble(Console.ReadLine());
		Console.Clear();
		Console.WriteLine($"A({Ax:0.##}:{Ay:0.##})\nB({Bx:0.##}:{By:0.##})\nC({Cx:0.##}:{Cy:0.##})\nD({Dx:0.##}:{Dy:0.##})");
		sides(Ax, Ay, Bx, By, Cx, Cy, Dx, Dy);
	}
	public static void sides(double Ax, double Ay, double Bx, double By, double Cx, double Cy, double Dx, double Dy) {
		double AB, BC, CD, AD;
		AB = Math.Sqrt(Math.Pow(Ax - Bx, 2) + Math.Pow(Ay - By, 2));
		BC = Math.Sqrt(Math.Pow(Bx - Cx, 2) + Math.Pow(By - Cy, 2));
		CD = Math.Sqrt(Math.Pow(Cx - Dx, 2) + Math.Pow(Cy - Dy, 2));
		AD = Math.Sqrt(Math.Pow(Ax - Dx, 2) + Math.Pow(Ay - Dy, 2));
		Console.WriteLine("\nСторони чотирикутника:");
		Console.WriteLine($"AB = {AB:0.##}\nBC = {BC:0.##}\nCD = {CD:0.##}\nAD = {AD:0.##}");
		double AC, BD;
		AC = Math.Sqrt(Math.Pow(Ax - Cx, 2) + Math.Pow(Ay - Cy, 2));
		BD = Math.Sqrt(Math.Pow(Bx - Dx, 2) + Math.Pow(By - Dy, 2));
		if (AB + BC > AC && BC + CD > BD && CD + AD > AC && AD + AB > BD) {
			Console.WriteLine("\nДiагоналi чотирикутника:");
			Console.WriteLine($"AC = {AC:0.##}\nBD = {BD:0.##}");
			angles(Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, AB, BC, CD, AD, AC, BD);
			perimeter(AB, BC, CD, AD);
			area(Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, AC, BD);
			pause();
		}
		else {
			Console.Write("\nЦей чотирикутник не iснує! Введiть ще раз.");
			Console.ReadLine();
			MainQuadrangle();
		}
	}
	public static void angles(double Ax, double Ay, double Bx, double By, double Cx, double Cy, double Dx, double Dy, double AB, double BC, double CD, double AD, double AC, double BD) {
		double A, B, C, D;
		A = Math.Acos((AB*AB + AD*AD - BD*BD)/(2*AB*AD)) / Math.PI * 180;
		B = Math.Acos((BC*BC + AB*AB - AC*AC)/(2*BC*AB)) / Math.PI * 180;
		C = Math.Acos((BC*BC + CD*CD - BD*BD)/(2*BC*CD)) / Math.PI * 180;
		D = Math.Acos((AD*AD + CD*CD - AC*AC)/(2*AD*CD)) / Math.PI * 180;
		Console.WriteLine($"\nКути чотирикутника\nA = {A:0.##}°\nB = {B:0.##}°\nC = {C:0.##}°\nD = {D:0.##}°");
		string aspect;
		Console.Write("\nТип чотирикутника:");
		if (A + B + C + D >= 359.9999) {
			aspect = "опуклий";
			Console.WriteLine($"\nЧотирикутник {aspect}");
		}
		else {
			aspect = "випуклий";
			Console.WriteLine($"\nЧотирикутник {aspect}");
		}
		parameters(Ax, Ay, Bx, By, Cx, Cy, Dx, Dy, AB, BC, CD, AD, A, B, C, D, aspect);
		inscribedCircle(AB, BC, CD, AD, aspect);
		circumscribedCircle(A, B, C, D, aspect);
	}
	public static void perimeter(double AB, double BC, double CD, double AD) {
		double P;
		P = (AB + BC + CD + AD);
		Console.WriteLine($"\nПериметр чотирикутника = {P:0.##}");
	}
	public static void area(double Ax, double Ay, double Bx, double By, double Cx, double Cy, double Dx, double Dy, double AC, double BD) {
		double d1d2 = Math.Acos(((Ax - Cx) * (Bx - Dx) + (Ay - Cy) * (By - Dy)) / AC / BD);
		double S = AC * BD / 2 * Math.Sin(d1d2);
		Console.WriteLine($"\nПлоща чотирикутника = {S:0.##}");
	}
	public static void inscribedCircle(double AB, double BC, double CD, double AD, string aspect) {
		if (AB + CD == BC + AD && aspect == "опуклий") {
			Console.WriteLine("\nУ чотирикутник можна вписати коло");
		}
		else {
			Console.WriteLine("\nУ чотирикутник не можна вписати коло");
		}
	}
	public static void circumscribedCircle(double A, double B, double C, double D, string aspect) {
		if (A + C == B + D && aspect == "опуклий") {
			Console.WriteLine("Чотирикутник можна описати колом");
		}
		else {
			Console.WriteLine("Чотирикутник не можна описати колом");
		}
	}
	public static void parameters(double Ax, double Ay, double Bx, double By, double Cx, double Cy, double Dx, double Dy, double AB, double BC, double CD, double AD, double A, double B, double C, double D, string aspect) {
		if ((Math.Abs((Ay - By) / (Ax - Bx)) == Math.Abs((Cy - Dy) / (Cx - Dx))) && (Math.Abs((Ay - Dy) / (Ax - Dx)) == Math.Abs((By - Cy) / (Bx - Cx))) && aspect != "випуклий") {
			Console.Write("У чотирикутника двi пари паралельних сторiн, ");
		}
		else if (((Math.Abs((Ay - By) / (Ax - Bx)) == Math.Abs((Cy - Dy) / (Cx - Dx))) || (Math.Abs((Ay - Dy) / (Ax - Dx)) == Math.Abs((By - Cy) / (Bx - Cx)))) && aspect != "випуклий") {
			Console.Write("У чотирикутника одна пара паралельних сторiн, ");
		}
		else {
			Console.Write("У чотирикутника немає паралельних сторiн, вiн неправильний");
		}
	}
	public static void pause() {
		Console.ReadLine();
	}
}
class Combined {
	static void Main() {
		Triangle.MainTriangle();
		Quadrangle.MainQuadrangle();
	}
}