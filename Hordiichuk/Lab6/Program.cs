using System;
using VectorLab; // Підключаємо простір імен з нашим класом

namespace VectorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Лабораторна робота: Перевантаження операторів ---");

            // 1. Створити два вектори v1 = (3, 4) та v2 = (1, -2)
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(1, -2);

            Console.WriteLine($"\nСтворено вектори:");
            Console.WriteLine($"v1 = {v1}");
            Console.WriteLine($"v2 = {v2}");

            // Додатково: виведемо довжину v1
            Console.WriteLine($"Довжина v1: {v1.GetLength():F2}"); // :F2 - форматування до 2 знаків

            // 2. Змінити знаки координат вектора v1
            // Оператор - створює НОВИЙ вектор
            Vector v1_neg = -v1;
            Console.WriteLine($"\n1. Унарний мінус (-v1):");
            Console.WriteLine($"-v1 = {v1_neg}");
            Console.WriteLine($"v1 (оригінал) = {v1}"); // v1 не змінився

            // 3. Додати вектори v1 і v2
            // Щоб слідувати прикладу "змінити знаки ... додати",
            // ми додамо v1_neg та v2.
            Vector sum = v1_neg + v2;
            Console.WriteLine($"\n2. Додавання (-v1 + v2):");
            Console.WriteLine($"{v1_neg} + {v2} = {sum}");

            // 4. Помножити вектор v2 на скаляр 2
            Console.WriteLine($"\n3. Множення v2 на скаляр 2:");
            Vector scaled_v2 = v2 * 2;
            Console.WriteLine($"{v2} * 2 = {scaled_v2}");

            // Демонстрація іншого порядку (скаляр * вектор)
            Vector scaled_v1 = 3 * v1;
            Console.WriteLine($"(додатково) 3 * {v1} = {scaled_v1}");


            // 5. Порівняти два вектори на рівність
            Console.WriteLine($"\n4. Порівняння:");
            Console.WriteLine($"{v1} == {v2} : {v1 == v2}"); // False
            Console.WriteLine($"{v1} != {v2} : {v1 != v2}"); // True

            // Створимо вектор, що дорівнює v1, для перевірки
            Vector v3 = new Vector(3, 4);
            Console.WriteLine($"{v1} == {v3} : {v1 == v3}"); // True
        }
    }
}