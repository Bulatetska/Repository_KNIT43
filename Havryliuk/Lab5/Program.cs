using System.Linq;
using System.Text;
namespace ConsoleApplication8
{
    // Абстрактний клас Figure - містить абстрактний метод Area() і абстрактну властивість Area2
 abstract class Figure
    {
        //приховане поле класу
        private string name; // Назва фігури
                             // конструктор класу
        public Figure(string name)
        {
            this.name = name;
        }

        //властивість доступу до поля класу
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        //Абстрактна властивість, яка повертає площу фігури
        public abstract double Area2 { get; }
        // абстрактний метод, який повертає площу фігури

        public abstract double Area();
        //віртуальний метод, який виводить значення полів класу
        public virtual void Print()
        {
            Console.WriteLine("name = {0}", name);
        }
    }
    

    //клас, що реалізує трикутник. У класі немає абстрактних методів,
    // тому слово abstract не ставиться перед оголошенням класу.
    class Triangle : Figure
    {
        //внутрішні поля класу
        double a, b, c;
        //конструктор класу
        public Triangle(string name, double a, double b, double c)
         : base(name)
        {
            //перевірка на коректність значень a, b, c
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


        //реалізація методів доступу до прихованих полів a, b, c
        //встановлення значень полів a, b, c
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


        //читання значень полів - звернути увагу на модифікатор out
        public void GetABC(out double a, out double b, out double c)
        {
            a = this.a; b = this.b; c = this.c;
        }
        // перевизначення абстрактної властивості Area2 класу Figure
        public override double Area2
        {
            get
            {
                //провести обчислення
                double p, s;
                p = (a + b + c) / 2;
                s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                //вивести результат у властивості - для контролю
                Console.WriteLine("Property Triangle.Area2: s = {0:f3}", s);
                //повернути результат
                return s;
            }
        }


        //реалізація методу Area(), який в класі Figure оголошений як абстрактний
        public override double Area()
        {
            //провести обчислення
            double p, s;
            p = (a + b + c) / 2;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            //вивести результат у властивості - для контролю
            Console.WriteLine("Method Triangle.Area(): s = {0:f3}", s);
            //повернути результат
            return s;
        }


        //віртуальний метод Print
        public override void Print()
        {
            base.Print();
            Console.WriteLine("a = {0:f2}", a);
            Console.WriteLine("b = {0:f2}", b);
            Console.WriteLine("c = {0:f2}", c);
        }
    }
 //клас, що визначає трикутник з кольором
class TriangleColor : Triangle
 {
 //приховане поле color
 private int color;
 //конструктор з 5 параметрами
 public TriangleColor(string name, double a, double b, double c, int
color) :
 base(name, a, b, c)
 {
 //перевірка на коректність задавання значення color
 if ((color >= 0) && (color <= 255))
 this.color = color;
 else
 this.color = 0;
 }
 //властивість доступу до поля color
public int Color
{
    get { return color; }
    set
    {
        // перевірка на коректність задавання значення color
        if (value >= 0 && value <= 255)
            color = value;
        else
            color = 0;
    }
}
 // властивість Area2 - викликає однойменну
 // властивість базового класу.
 public override double Area2
 {
 get
 { 
 Console.WriteLine("Property TriangleColor.Area2:");
 return base.Area2; 
 }
 }
 public override double Area()
 {
 Console.WriteLine("Method TriangleColor.Area():");
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

 Figure refFg;
 
 Triangle Tr = new Triangle("Triangle", 2, 3, 2);
 TriangleColor TrCol = new TriangleColor("TriangleColor", 1, 3, 3, 0);

 refFg = Tr;
 refFg.Print();
 refFg = TrCol;
 refFg.Print();

 refFg = Tr;
 refFg.Area(); 
 refFg = TrCol;
 refFg.Area(); 

 refFg = Tr;
 double area = refFg.Area2; 
 Console.WriteLine("area = {0:f3}", area);
 refFg = TrCol;
 area = refFg.Area2; 
 Console.WriteLine("area = {0:f3}", area);
 Console.ReadKey();
 }
}
}