// Доробити програму з лекції про абстрактний клас Figure та Triangle, додавши до неї ще один клас.

namespace Lab5
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

    // Розробити клас TriangleColor, який успадковує (розширює) можливості класу Triangle.
    // У класі реалізувати наступні елементи:
    // - приховане внутрішнє поле color (колір фону трикутника);
    // - конструктор з 5 параметрами, який викликає конструктор базового класу;
    // - властивість Color, яка призначена для доступу до внутрішнього поля color;
    // - властивість Area2, яка викликає однойменну властивість базового класу для обчислення площі трикутника;
    // - метод Area(), який повертає площу трикутника за його сторонами;
    // - віртуальний метод Print() для виведення внутрішніх полів класу.
    //   Метод звертається до однойменного методу базового класу. 

    class TriangleColor : Triangle
    {
        private string color;

        public TriangleColor(string name, double a, double b, double c, string color) : base(name, a, b, c)
        {
            this.color = color;
        }

        public string Color { get => color; set => color = value; }

        public override double Area2 {
            get
            {
                Console.WriteLine("Called TriangleColor.Area2 get");
                return base.Area2;
            }
        }

        public override double Area()
        {
            Console.WriteLine("Called TriangleColor.Area()");
            return base.Area();
        }

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
            // Демонстрація поліморфізму з використанням
            // абстрактного класу.
            // 1. Оголосити посилання на базовий клас
            Figure refFg;
            // 2. Оголосити екземпляр класу Figure
            // 2.1. Неможливо створити екземпляр абстрактного класу
            // Figure objFg = new Figure("Figure"); - помилка!
            // 2.2. Оголосити екземпляри класів Triangle, TriangleColor
            Triangle Tr = new Triangle("Triangle", 2, 3, 2);
            TriangleColor TrCol = new TriangleColor("TriangleColor", 1, 3, 3, "red");
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
        }
    }
}