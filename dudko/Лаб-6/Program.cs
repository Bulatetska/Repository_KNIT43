using System;

namespace VectorApp // Оголошення простору імен
{
    class Vector // Оголошуємо клас Vector
    {
        private double x, y; // Закриті поля для координат вектора

        // Конструктор з параметрами
        public Vector(double x, double y) // Приймає значення координат
        {
            this.x = x; // Присвоюємо значення в поле x
            this.y = y; // Присвоюємо значення в поле y
        }

        // Властивість для доступу до x
        public double X
        {
            get { return x; } // Повертає значення x
            set { x = value; } // Встановлює значення x
        }

        // Властивість для доступу до y
        public double Y
        {
            get { return y; } // Повертає значення y
            set { y = value; } // Встановлює значення y
        }

        // Перевантаження унарного мінуса
        public static Vector operator -(Vector v) // Вхідний вектор v
        {
            return new Vector(-v.x, -v.y); // Створюємо новий вектор з протилежними координатами
        }

        // Перевантаження оператора додавання
        public static Vector operator +(Vector a, Vector b) // Додаємо два вектори
        {
            return new Vector(a.x + b.x, a.y + b.y); // Повертаємо новий вектор з сумою координат
        }

        // Перевантаження множення (вектор * число)
        public static Vector operator *(Vector v, double scalar) // scalar - число
        {
            return new Vector(v.x * scalar, v.y * scalar); // Множимо координати на скаляр
        }

        // Перевантаження множення (число * вектор)
        public static Vector operator *(double scalar, Vector v) // Для випадку коли число зліва
        {
            return new Vector(v.x * scalar, v.y * scalar); // Те ж саме, що й вище
        }

        // Перевантаження оператора рівності
        public static bool operator ==(Vector a, Vector b) // Порівнюємо два вектори
        {
            return a.x == b.x && a.y == b.y; // Рівні тільки якщо обидві координати однакові
        }

        // Перевантаження оператора нерівності
        public static bool operator !=(Vector a, Vector b) // Протилежне оператору ==
        {
            return !(a == b); // Використовуємо попередній оператор
        }

        // Метод обчислення довжини вектора
        public double Length()
        {
            return Math.Sqrt(x * x + y * y); // Формула √(x² + y²)
        }

        // Метод виведення вектора
        public void Print(string name) // name — назва (наприклад v1)
        {
            Console.WriteLine($"{name} = ({x}, {y}), |{name}| = {Length():F2}"); // Виводимо координати і довжину
        }
    }

    class Program // Головний клас програми
    {
        static void Main(string[] args) // Точка входу
        {
            Vector v1 = new Vector(3, 4); // Створюємо вектор (3,4)
            Vector v2 = new Vector(1, -2); // Створюємо інший вектор (1,-2)

            v1.Print("v1"); // Виводимо перший вектор
            v2.Print("v2"); // Виводимо другий вектор

            Vector v1Neg = -v1; // Викликаємо унарний мінус
            v1Neg.Print("−v1"); // Виводимо результат

            Vector sum = v1 + v2; // Складаємо вектори
            sum.Print("v1 + v2"); // Виводимо суму

            Vector mult = v2 * 2; // Множимо вектор на 2
            mult.Print("v2 * 2"); // Виводимо результат

            Console.WriteLine(v1 == v2 ? "v1 == v2" : "v1 != v2"); // Перевіряємо рівність

            Console.ReadKey(); // Чекаємо натискання клавіші, щоб консоль не закрилась
        }
    }
}
