using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApplication8
{
    // Абстрактний клас Figure - містить абстрактний метод Area()
    // і абстрактну властивість Area2
    abstract class Figure
    {
        // 1. Приховане поле класу
        private string name; // Назва фігури
                             // 2. Конструктор класу
        public Figure(string name)
        {
            this.name = name;
        }
        // 3. Властивість доступу до поля класу
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // 4. Абстрактна властивість, яка повертає площу фігури
        public abstract double Area2 { get; }
        // 5. Абстрактний метод, який повертає площу фігури
        // Метод не має тіла методу
        public abstract double Area();
        // 6. Віртуальний метод, який виводить значення полів класу
        public virtual void Print()
        {
            Console.WriteLine("name = {0}", name);
        }
    }
    // Клас, що реалізує трикутник. У класі немає абстрактних методів,
    // тому слово abstract не ставиться перед оголошенням класу.
    class Triangle : Figure
    {
        // 1. Внутрішні поля класу
        double a, b, c;
        // 2. Конструктор класу
        public Triangle(string name, double a, double b, double c)
         : base(name)
        {
            // Перевірка на коректність значень a, b, c
            if (((a + b) > c) && ((b + c) > a) && ((a + c) > b))
            {
                this.a = a; this.b = b; this.c = c;
            }
            else
            {
                Console.WriteLine("Incorrect values a, b, c.");
                Console.WriteLine("By default: a=1, b=1, c=1.");
                this.a = this.b = this.c = 1;
            }
        }
        // 3. Реалізація методів доступу до прихованих полів a, b, c
        // 3.1. Встановлення значень полів a, b, c
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
        // 3.2. Читання значень полів - звернути увагу на модифікатор out
        public void GetABC(out double a, out double b, out double c)
        {
            a = this.a; b = this.b; c = this.c;
        }
        // 4. Перевизначення абстрактної властивості Area2 класу Figure,
        // ключове слово override обов'язкове
        public override double Area2
        {
            get
            {
                // 1. Провести обчислення
                double p, s;
                p = (a + b + c) / 2;
                s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                // 2. Вивести результат у властивості - для контролю
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);
                // 3. Повернути результат
                return s;
            }
        }
        // 5. Реалізація методу Area(), який в класі Figure
        // оголошений як абстрактний
        public override double Area()
        {
            // 1. Провести обчислення
            double p, s;
            p = (a + b + c) / 2;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            // 2. Вивести результат у властивості - для контролю
            Console.WriteLine("Method Triangle.Area(): s = {0:f3}", s);
            // 3. Повернути результат
            return s;
        }
        // 6. Віртуальний метод Print
        public override void Print()
        {
            base.Print();
            Console.WriteLine("a = {0:f2}", a);
            Console.WriteLine("b = {0:f2}", b);
            Console.WriteLine("c = {0:f2}", c);
        }
    }
    // Клас, що визначає трикутник з кольором

    class TriangleColor : Triangle
    {
        // 1. Приховане поле color
        private int color;
        
        // 2. Конструктор з 5 параметрами
        public TriangleColor(string name, double a, double b, double c, int
       color) :
        base(name, a, b, c)
        {
            
            // Перевірка на коректність задавання значення color
            if ((color >= 0) && (color <= 255))
                this.color = color;
            else
                this.color = 0;
        }
        // 3. Властивість доступу до поля color
        public int Color
        {
           
            get { return color; }
            set
            {
                
                // Перевірка на коректність задавання значення color
                if ((color >= 0) && (color <= 255))
                    color = value;
                else
                    color = 0;
            }
            
        }
        // 4. Властивість Area2 - викликає однойменну
        // властивість базового класу.
        public override double Area2
        {
            get
            {
                // 1. Попередньо вивести контрольне повідомлення
                Console.WriteLine("Property TriangleColor.Area2:");
                // 2. Викликати властивість базового класу
                return base.Area2;
            }
        }
        // 5. Абстрактний метод Area()
        public override double Area()
        {
            // 1. Вивести контрольне повідомлення
            Console.WriteLine("Method TriangleColor.Area():");
            // 2. Викликати властивість базового класу
            return base.Area();
        }
        // 6. Віртуальний метод Print()
        public override void Print()
        {
            base.Print();
            Console.WriteLine("color = {0}", color);
        }
    }
    class Program
    {
        static void Main(string[] args)

        {
              Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The solution from the lecture fits all the requirements.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("I just copied everything from lecture all coments and code are the same, exept Console.... mesages, because it is dont need to be changed");
            Console.ResetColor();
            Console.WriteLine("The 'color' declared as private and kind of hiding under that name and in the future needs to be incapsulated");
            Console.WriteLine("The lecture contained the exact five-parameter constructor required and with base class:\r\n(string name, double a, double b, double c, int color) :\r\n        base(name, a, b, c)");
            Console.WriteLine("The 'Color' wrote as property and have GET/SET methods, which is designed to access the internal 'color' field");
            Console.WriteLine("The 'Area2' property and 'Area()','Print()' method both 'override' the base class implementations and call them using base.Area2 and base.Area(), base.Print");

            // Демонстрація поліморфізму з використанням
            // абстрактного класу.
            // 1. Оголосити посилання на базовий клас
            Figure refFg;
            // 2. Оголосити екземпляр класу Figure
            // 2.1. Неможливо створити екземпляр абстрактного класу
            // Figure objFg = new Figure("Figure"); - помилка!
            // 2.2. Оголосити екземпляри класів Triangle, TriangleColor
            Triangle Tr = new Triangle("Triangle", 2, 3, 2);
            /*Екземпляр класу TriangleColor з 5 параметрами */
            TriangleColor TrCol = new TriangleColor("TriangleColor", 1, 3, 3, 0);
            // 3. Демонстрація поліморфізму на прикладі методу Print()
            refFg = Tr;
            refFg.Print();
            refFg = TrCol;
            refFg.Print();
            // 4. Демонстрація поліморфізму на прикладі методу Area()
            refFg = Tr;
            refFg.Area(); // викликається метод Triangle.Area()
            refFg = TrCol;
            refFg.Area(); // викликається метод TriangleColor.Area()
                          // 5. Демонстрація поліморфізму на прикладі властивості Area2
            refFg = Tr;
            double area = refFg.Area2; // властивість Triangle.Area2
            Console.WriteLine("area = {0:f3}", area);
            refFg = TrCol;
            area = refFg.Area2; // властивість TriangleColor.Area2
            Console.WriteLine("area = {0:f3}", area);
            Console.ReadKey();
        }
    }
}