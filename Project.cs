using System;

public class Triangle {
	public static void MainTriangle() {
		Console.Clear();
		double Ax, Ay, Bx, By, Cx, Cy;
		Console.WriteLine("Введiть координати вершин трикутника:\nТочка A:");
		Ax = Convert.ToDouble(Console.ReadLine());
		Ay = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Точка B:");
		Bx = Convert.ToDouble(Console.ReadLine());
		By = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Точка C:");
		Cx = Convert.ToDouble(Console.ReadLine());
		Cy = Convert.ToDouble(Console.ReadLine());
		Console.Clear();
		Console.WriteLine($"A({Ax:0.##}:{Ay:0.##})\nB({Bx:0.##}:{By:0.##})\nC({Cx:0.##}:{Cy:0.##})");
		sides(Ax, Ay, Bx, By, Cx, Cy);
	}
	public static void sides(double Ax, double Ay, double Bx, double By, double Cx, double Cy) {
		double AB, BC, AC;
		AB = Math.Sqrt(Math.Pow(Ax - Bx, 2) + Math.Pow(Ay - By, 2));
		BC = Math.Sqrt(Math.Pow(Bx - Cx, 2) + Math.Pow(By - Cy, 2));
		AC = Math.Sqrt(Math.Pow(Ax - Cx, 2) + Math.Pow(Ay - Cy, 2));
		Console.WriteLine("\nAB = {0:0.##}\nBC = {1:0.##}\nAC = {2:0.##}", AB, BC, AC);
		if (AB + BC > AC && BC + AC > AB && AC + AB > BC) {
			halfPerimeter(AB, BC, AC);
			angles(AB, BC, AC);
			string biggestAngle;
			double inaccuracy = 0.00001;
			if (AC*AC > AB*AB + BC*BC + inaccuracy || AB*AB > BC*BC + AC*AC + inaccuracy || BC*BC > AC*AC + AB*AB + inaccuracy) {
				biggestAngle = "тупокутний";
			}
			else if (AC*AC > AB*AB + BC*BC - inaccuracy || AB*AB > BC*BC + AC*AC - inaccuracy || BC*BC > AC*AC + AB*AB - inaccuracy) {
				biggestAngle = "прямокутний";
			}
			else {
				biggestAngle = "госторокутний";
			}
			parameters(AB, BC, AC, biggestAngle);
			pause();
		}
		else {
			Console.Write("\nЦей трикутник не iснує! Введiть ще раз.");
			Console.ReadLine();
			MainTriangle();
		}
	}
	public static void halfPerimeter(double AB, double BC, double AC) {
		double p = ((AB + BC + AC) / 2);
		Console.WriteLine("\nПериметр трикутника = {0:0.##}", p * 2);
		area(AB, BC, AC, p);
		inscribedCircle(AB, BC, AC, p);
	}
	public static void area(double AB, double BC, double AC, double p) {
		double S = Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
		Console.WriteLine("\nПлоща трикутника = {0:0.##}", S);
		heights(AB, BC, AC, S);
		circumscribedCircle(AB, BC, AC, S);
	}
	public static void angles(double AB, double BC, double AC) {
		double A, B, C;
		A = Math.Acos((AB*AB + AC*AC - BC*BC)/(2*AB*AC)) / Math.PI * 180;
		B = Math.Acos((BC*BC + AB*AB - AC*AC)/(2*BC*AB)) / Math.PI * 180;
		C = Math.Acos((BC*BC + AC*AC - AB*AB)/(2*BC*AC)) / Math.PI * 180;
		Console.WriteLine("\nКути трикутника\nA = {0:0.##}°\nB = {1:0.##}°\nC = {2:0.##}°", A, B, C);
	}
	public static void medians(double AB, double BC, double AC) {
		double aMedian, bMedian, cMedian;
		aMedian = Math.Sqrt(2*BC*BC + 2*AC*AC - AB*AB) / 2;
		bMedian = Math.Sqrt(2*AB*AB + 2*AC*AC - BC*BC) / 2;
		cMedian = Math.Sqrt(2*BC*BC + 2*AB*AB - AC*AC) / 2;
		Console.WriteLine("\nМедiана до сторони AB = {0:0.##}\nМедiана до сторони BC = {1:0.##}\nМедiана до сторони AC = {2:0.##}", aMedian, bMedian, cMedian);
	}
	public static void heights(double AB, double BC, double AC, double S) {
		double aHeight, bHeight, cHeight;
		aHeight = 2 * S / AB;
		bHeight = 2 * S / BC;
		cHeight = 2 * S / AC;
		Console.WriteLine("\nВисота до сторони AB = {0:0.##}\nВисота до сторони BC = {1:0.##}\nВисота до сторони AC = {2:0.##}", aHeight, bHeight, cHeight);
		medians(AB, BC, AC);
		bisectors(AB, BC, AC);
	}
	public static void bisectors(double AB, double BC, double AC) {
		double alphaBisector, betaBisector, gammaBisector;
		alphaBisector = Math.Sqrt(AC * BC * (AC + BC + AB) * (AC + BC - AB)) / (AC + BC);
		betaBisector = Math.Sqrt(AB * AC * (AB + AC + BC) * (AB + AC - BC)) / (AB + AC);
		gammaBisector = Math.Sqrt(AB * BC * (AB + BC + AC) * (AB + BC - AC)) / (AB + BC);
		Console.WriteLine("\nБiсектриса кута A = {0:0.##}\nБiсектриса кута B = {1:0.##}\nБiсектриса кута C = {2:0.##}", alphaBisector, betaBisector, gammaBisector);
	}
	public static void inscribedCircle(double AB, double BC, double AC, double p) {
		double r;
		r = Math.Sqrt((p - AB) * (p - BC) * (p - AC) / p);
		Console.WriteLine("\nРадiус вписаного кола = {0:0.##}", r);
	}
	public static void circumscribedCircle(double AB, double BC, double AC, double S) {
		double R;
		R = AB * BC * AC / S / 4;
		Console.WriteLine("\nРадiус описаного кола = {0:0.##}", R);
	}
	public static void parameters(double AB, double BC, double AC, string biggestAngle) {
		Console.Write("\nТип трикутника:");
		if (AB == BC && BC == AC) {
			Console.WriteLine("\nТрикутник рiвностороннiй i " + biggestAngle);
		}
		else if (AB == BC || BC == AC || AC == AB) {
			Console.WriteLine("\nТрикутник рiвнобедрений i " + biggestAngle);
		}
		else {
			Console.WriteLine("\nТрикутник рiзностороннiй i " + biggestAngle);
		}
	}
	public static void pause() {
		Console.ReadLine();
	}
}
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
			Console.Write("У чотирикутника двi пари паралельних сторiн");
		}
		else if (((Math.Abs((Ay - By) / (Ax - Bx)) == Math.Abs((Cy - Dy) / (Cx - Dx))) || (Math.Abs((Ay - Dy) / (Ax - Dx)) == Math.Abs((By - Cy) / (Bx - Cx)))) && aspect != "випуклий") {
			Console.Write("У чотирикутника одна пара паралельних сторiн");
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