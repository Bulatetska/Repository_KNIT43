using System;

namespace PersonApp
{
    class Person
    {
        private String name;
        private int age;
        private String sex;
        private String phone_number;

        public void SetName(String newN)
        {
            name = newN;
        }
        public void SetAge(int newAge)
        {
            age = newAge;
        }
        public void SetSex(String newSex)
        {
            sex = newSex;
        }  
        public void SetPhone(String newPhone)
        {
            phone_number = newPhone;
        }
        public void Print()
        {
            Console.WriteLine("\n ----Person---- \n Name: " + name + "\n Age: " + age + "\n Sex: " + sex + "\n Phone number: " + phone_number);
        }
    }

    class Student
    {
        private String surname;
        private int kurs;
        private int number_zalikovky;
        public Student()
        {
            surname = "";
            kurs = 0;
            number_zalikovky = 0;
        }
        public Student(String s, int k, int n)
        {
            this.surname = s;
            this.kurs = k;
            this.number_zalikovky = n;
        }
        public void SetSurname(String newSurname)
        {
            this.surname = newSurname;
        }
        public void SetKurs(int newKurs)
        {
            this.kurs = newKurs;   
        }
        public void SetNumber(int newNumber)
        {
            this.number_zalikovky = newNumber;
        }
        public String GetSurname()
        {
            return surname;
        }
        public int GetKurs()
        {
            return kurs;
        }
        public int GetNumberZalikovky()
        {
            return number_zalikovky;
        }
        public virtual void Print()
        {
            Console.WriteLine("\n ----Student---- \n Surname: " + surname + "\n Kurs: " + kurs + "\n Number zalikovky: " + number_zalikovky);
        }

    }

    class Aspirant: Student
    {
        public String Dissertation { get; set; }
        public Aspirant(String s, int k, int n, String d) : base(s, k, n)
        {
            Dissertation = d;
        }
        public override void Print()
        {
            base.Print();
            Console.Write(" Dissertation: " + Dissertation);
        }
    }

    class Book
    {
        public String title { get; set; }
        public String surname_name { get; set; }
        public int price { get; set; }
        public Book(String t, String s, int p)
        {
            this.title = t;
            this.surname_name = s;
            this.price = p;
        }
        public virtual void Print()
        {
            Console.WriteLine("----Book---- \n Book title: " + title + "\n Author: " + surname_name + "\n Book price: " + price);

        }
    }

    class BookGenre : Book
    {
        private String genre { get; set; }
        public BookGenre(String t, String s, int p, String genre) : base(t, s, p)
        {
            this.genre = genre;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Genre: " + genre);
        }
    }

    sealed class BookGenrePubl: BookGenre
    {
        private String publisher { get; set; }
        public BookGenrePubl(String t, String s, int p, String g, String pp) : base(t, s, p, g)
        {
            this.publisher = pp;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Publisher: " + publisher);
        }
    }

    class Figure
    {
        public String name;
        public Figure(String n)
        {
            this.name = n;
        }
        public virtual void Display()
        {
            Console.WriteLine("\n ----Figure---- \n Type of the figure: " +  name);
        }
    }
    class Rectangle : Figure
    {
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public Rectangle(String n, int x1, int x2, int y1, int y2) : base(n)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        public Rectangle() : this("Rectangle", 0, 0, 1, 1) { }
        public override void Display()
        {
            base.Display();
            Console.WriteLine(" x1 = " + x1 + ", \n x2 = " + x2 + ", \n y1 = " + y1 + ", \n y2 = " + y2);
        }
        public int Area()
        {
            return Math.Abs((x2-x1)*(y2-y1));
        }
    }
    class RectangleColor : Rectangle
    {
        private String color;
        public RectangleColor(String c, String n, int x1, int x2, int y1, int y2) : base(n, x1, x2, y1, y2)
        {
            this.color = c;
        }
        public RectangleColor() : this("Black", "Rectangle", 0, 1, 0, 1) { }
        public override void Display()
        {
            base.Display();
            Console.WriteLine(" color: " +  color);
        }
        public int Area()
        {
            return base.Area();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Zadanie 1 

            Person p = new Person();
            p.SetName("Oksana");
            p.SetAge(19);
            p.SetSex("woman");
            p.SetPhone("+38026655423");
            p.Print();

            //Zadanie 2

            Student s = new Student();
            s.Print();
            s.SetSurname("Pavliuk");
            s.SetKurs(4);
            s.SetNumber(22052);
            s.Print();

            Aspirant a = new Aspirant("Anna", 1, 220252, "asd");
            a.Print();

            //Zadanie 3
            BookGenrePubl bp = new BookGenrePubl("Moonknight", "A.A.Smilam", 250, "romcom", "Pajak");
            bp.Print();

            //Zadanie 4
            Figure f;
            f = new Rectangle("MyRect", 2, 3, 4, 5);
            f.Display();
            Console.WriteLine($"Area: {(f as Rectangle).Area()}");

            f = new RectangleColor("Red", "My", 1, 2, 3, 4);
            f.Display();
            Console.WriteLine($"Area: {(f as RectangleColor).Area()}");

        }
    }
}