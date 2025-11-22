using System;

namespace VectorLab
{
    public class Vector
    {
        // 1. Властивості для координат
        public double X { get; }
        public double Y { get; }

        // 2. Конструктор для ініціалізації
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        // 3. Метод для отримання довжини вектора
        public double GetLength()
        {
            // Використовуємо теорему Піфагора: sqrt(x^2 + y^2)
            return Math.Sqrt(X * X + Y * Y);
        }

        // 4. Метод для виведення (перевизначення ToString)
        // Це стандартний спосіб для "виведення на екран"
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        // --- Перевантаження операторів ---

        // 5. Унарний мінус (-)
        // Змінює знаки обох координат
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

        // 6. Бінарний оператор додавання (+)
        // Додає відповідні координати двох векторів
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        // 7. Оператор множення (*) на скаляр (число)
        // Множить кожну координату на число
        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar);
        }

        // 7b. Перевантаження для комутативності (скаляр * вектор)
        // Дозволяє писати '2 * v' так само, як 'v * 2'
        public static Vector operator *(double scalar, Vector v)
        {
            // Просто викликаємо попередній оператор
            return v * scalar;
        }

        // 8. Оператор рівності (==)
        public static bool operator ==(Vector v1, Vector v2)
        {
            // Обробка null-значень (хороша практика)
            if (ReferenceEquals(v1, null))
            {
                return ReferenceEquals(v2, null);
            }
            if (ReferenceEquals(v2, null))
            {
                return false; // v1 не null, v2 - null
            }

            // Порівняння за значеннями
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        // 9. Оператор нерівності (!=)
        // Завжди має бути реалізований в парі з (==)
        public static bool operator !=(Vector v1, Vector v2)
        {
            // Просто інвертуємо результат (==)
            return !(v1 == v2);
        }

        // 10. Перевизначення Equals та GetHashCode (найкраща практика)
        // Коли ви перевантажуєте == та !=, C# вимагає
        // також перевизначити ці методи.
        public override bool Equals(object obj)
        {
            // Перевіряємо, чи об'єкт є вектором, і викликаємо наш оператор ==
            if (obj is Vector v)
            {
                return this == v;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Використовуємо HashCode.Combine для генерації унікального хешу
            return HashCode.Combine(X, Y);
        }
    }
}