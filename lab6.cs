using System;
class Triangle
{
    public int x1, y1, x2, y2, x3, y3;
    public double S(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        double s;
        s = Math.Abs((double)1 /2 *((x1*y2 + x2*y3 + x3*y1)-(y1*x2 + y2*x3 + y3*x1)));
        return s;
    }
    public void L(Triangle t1, Triangle t2, Triangle t3)
    {
        double a = t1.S(t1.x1, t1.y1, t1.x2, t1.y2, t1.x3, t1.y3);
        double b = t2.S(t2.x1, t2.y1, t2.x2, t2.y2, t2.x3, t2.y3);
        double c = t3.S(t3.x1, t3.y1, t3.x2, t3.y2, t3.x3, t3.y3);
        if (a <= b && a <= c)
        {
            Console.WriteLine("S(t1) = " + a + ", S(t2) = " + b + ", S(t3) = " + c + " min S - t1");
        }
        else if (b <= a && b <= c)
        {
            Console.WriteLine("S(t1) = " + a + ", S(t2) = " + b + ", S(t3) = " + c + " min S - t2");
        }
        else if (c <= a && c <= b)
        {
            Console.WriteLine("S(t1) = " + a + ", S(t2) = " + b + ", S(t3) = " + c + " min S - t3");
        }
           
    }

}
class Program
{
    static void Main()
    {
        Triangle t1 = new Triangle();
        t1.x1 = 1; t1.y1 = 5;
        t1.x2 = 6; t1.y2 = -4;
        t1.x3 = -2; t1.y3 = 1;
        Triangle t2 = new Triangle();
        t2.x1 = 2; t2.y1 = 2;
        t2.x2 = 3; t2.y2 = 4;
        t2.x3 = 1; t2.y3 = 2;
        Triangle t3 = new Triangle();
        t3.x1 = 2; t3.y1 = 10;
        t3.x2 = 7; t3.y2 = -5;
        t3.x3 = -4; t3.y3 = 2;
        Triangle t = new Triangle();
        t.L(t1, t2, t3);
    }
}
