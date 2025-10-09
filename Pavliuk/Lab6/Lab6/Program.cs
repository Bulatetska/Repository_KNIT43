using System;
class Vector {
    public int x { get; set; }
    public int y { get; set; }
    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public static Vector operator-(Vector v1)
    {
        return new Vector(-v1.x, -v1.y);
    }
    public static Vector operator+(Vector v1, Vector v2) {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    }
    public static int operator *(Vector v1, Vector v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }
    public static Vector operator*(Vector v1, int a)
    {
        return new Vector(v1.x*a, v1.y*a);
    }
    public static bool operator==(Vector v1, Vector v2) { 
        if(v1.x==v2.x && v1.y == v2.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(Vector v1, Vector v2) { 
        return !(v1 == v2);
    }
    public void Print()
    {
        Console.WriteLine("----Vector----\n (" + this.x + ", " + this.y + ")");
    }
    public double Length()
    {
        return (Math.Sqrt(Math.Pow(this.x,2)+ Math.Pow(this.y,2)));
    }
}
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);
            Console.WriteLine("Початковий вектор v1");
            v1.Print();
            Console.WriteLine("Довжина вектора: " + v1.Length());
            Console.WriteLine("\nПочатковий вектор v2");
            v2.Print();
            Console.WriteLine("Довжина вектора: " + v2.Length());
            v1 = -v1;
            Console.WriteLine("\n Вектор v1 після застосування оператора унарного мінусу:");
            v1.Print();
            Vector v3 = v1 + v2;
            Console.WriteLine("\n Новий вектор v3 після застосування операції додавання:");
            v3.Print();
            Console.Write("\n Перевантаження операторів рівності та нерівності: \n v1 == v3:");
            Console.Write(v1 == v3);
            Console.Write("\n v1 == v3:");
            Console.Write(v2 == v3);
            Console.Write("\n v1 == v3:");
            Console.Write(v1 != v3);
            Console.Write("\n v1 == v3:");
            Console.Write(v2 != v3);
            Vector v4 = v2*10;
            Console.WriteLine("\n \n Новий вектор v4 після застосування операції множення на скаляр:");
            v4.Print();
        }
    }
}
