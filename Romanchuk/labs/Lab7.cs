using System;
class Program {

    class Vector {
        public int x, y;
        public Vector(int x, int y) {
            this.x = x;
            this.y = y;
        }
        public void Print() {
            Console.WriteLine($"Vector: ({this.x}, {this.y})");
        }

        public double Length() {
            return Math.Sqrt(x * x + y * y);
        }

        public static Vector operator -(Vector v) {
            return new Vector(-v.x, -v.y);
        }

        public static Vector operator +(Vector v1, Vector v2) {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static bool operator ==(Vector v1, Vector v2) {
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector v1, Vector v2) {
            return v1.x != v2.x || v1.y != v2.y;
        }

        public static Vector operator *(Vector v, int scalar) {
            return new Vector(v.x * scalar, v.y * scalar);
        }
    }
    static void Main(string[] args) {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, -2);
        Vector v3 = -v1;
        Vector v4 = v1 + v2;
        Vector v5 = v1 * 2;
        v1.Print();
        v2.Print();
        v3.Print();
        v4.Print();
        v5.Print();
        Console.WriteLine($"Length of v1: {v1.Length()}");
        Console.WriteLine($"v1 == v2: {v1 == v2}");
        Console.WriteLine($"v1 != v2: {v1 != v2}");
    }
}