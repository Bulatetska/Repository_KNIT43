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
				biggestAngle = "тупокутний.";
			}
			else if (AC*AC > AB*AB + BC*BC - inaccuracy || AB*AB > BC*BC + AC*AC - inaccuracy || BC*BC > AC*AC + AB*AB - inaccuracy) {
				biggestAngle = "прямокутний.";
			}
			else {
				biggestAngle = "госторокутний.";
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