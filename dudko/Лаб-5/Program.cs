using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    // Абстрактний клас Figure — базовий клас для всіх фігур
    abstract class Figure
    {

        private string name; // Назва фігури

        // Конструктор класу Figure — задає назву фігури при створенні об'єкта
        public Figure(string name)
        {
            this.name = name;
        }

        // Властивість для доступу до поля name ззовні класу
        public string Name
        {
            get { return name; } // Повертає назву фігури
            set { name = value; } // Змінює назву фігури
        }

        // Абстрактна властивість для обчислення площі — має реалізуватися у похідних класах
        public abstract double Area2 { get; }

        // Абстрактний метод для обчислення площі — має реалізуватися у похідних класах
        public abstract double Area();

        // Віртуальний метод для виводу інформації про фігуру
        public virtual void Print()
        {
            Console.WriteLine("name = {0}", name); // Виводимо назву фігури
        }
    }

    // Клас Triangle — реалізує конкретну фігуру "трикутник"
    class Triangle : Figure
    {
        // Три сторони трикутника
        double a, b, c;

        // Конструктор класу Triangle
        public Triangle(string name, double a, double b, double c) : base(name) // Викликає конструктор базового класу для name
        {
            // Перевірка, чи існує такий трикутник (сума двох сторін > третьої)
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c; // Присвоюємо значення сторін
            }
            else
            {
                Console.WriteLine("Incorrect values a, b, c."); // Виводимо повідомлення про помилку
                Console.WriteLine("By default: a=1, b=1, c=1."); // Встановлюємо значення за замовчуванням
                this.a = this.b = this.c = 1;
            }
        }

        // Метод для зміни сторін трикутника
        public void SetABC(double a, double b, double c)
        {
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c;
            }
            else
            {
                this.a = this.b = this.c = 1;
            }
        }

        // Метод для отримання значень сторін трикутника
        public void GetABC(out double a, out double b, out double c)
        {
            a = this.a; b = this.b; c = this.c;
        }

        // Перевизначена властивість Area2 для обчислення площі через формулу Герона
        public override double Area2
        {
            get
            {
                double p = (a + b + c) / 2; // Полупериметр трикутника
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Площа через формулу Герона
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s); // Вивід площі для контролю
                return s; // Повертаємо площу
            }
        }

        // Перевизначений метод Area() — робить те саме, що Area2
        public override double Area()
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Method Triangle.Area(): s = {0:f3}", s); // Вивід площі
            return s;
        }

        // Перевизначений метод Print() — виводить всі дані трикутника
        public override void Print()
        {
            base.Print(); // Викликаємо Print() базового класу (назву фігури)
            Console.WriteLine("a = {0:f2}", a); // Виводимо сторону a
            Console.WriteLine("b = {0:f2}", b); // Виводимо сторону b
            Console.WriteLine("c = {0:f2}", c); // Виводимо сторону c
        }
    }

    // Новий клас TriangleColor — трикутник з кольором
    class TriangleColor : Triangle
    {
        private string color; // Колір фону трикутника

        // Конструктор з 5 параметрами — викликає конструктор базового класу
        public TriangleColor(string name, double a, double b, double c, string color)
            : base(name, a, b, c)
        {
            this.color = color; // Присвоюємо колір
        }

        // Властивість для доступу до кольору
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        // Властивість Area2 — використовує базову реалізацію
        public new double Area2
        {
            get { return base.Area2; }
        }

        // Метод Area() — викликає базовий метод
        public new double Area()
        {
            return base.Area();
        }

        // Перевизначений метод Print() — виводить дані трикутника і колір
        public override void Print()
        {
            base.Print(); // Вивід даних базового трикутника
            Console.WriteLine("color = {0}", color); // Вивід кольору
        }
    }

    // Основна програма
    class Program
    {
        static void Main(string[] args)
        {
            // Вивід інформації про простий трикутник
            Console.WriteLine("=== Triangle ===");
            Figure Tr = new Triangle("Triangle", 2, 3, 2); // Створюємо екземпляр трикутника
            Tr.Print(); // Виводимо дані
            Tr.Area(); // Обчислюємо площу через метод
            double area1 = Tr.Area2; // Обчислюємо площу через властивість

            // Вивід інформації про кольоровий трикутник
            Console.WriteLine("\n=== TriangleColor ===");
            Figure Tc = new TriangleColor("Colored Triangle", 3, 4, 5, "Red"); // Створюємо кольоровий трикутник
            Tc.Print(); // Виводимо дані
            Tc.Area(); // Обчислюємо площу через метод
            double area2 = Tc.Area2; // Обчислюємо площу через властивість

            Console.ReadKey(); // Очікуємо натискання клавіші перед закриттям
        }
    }
}
