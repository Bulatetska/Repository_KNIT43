using Lab_5.task_1;
using Lab_5.task_2;
using Lab_5.task_3;
using Lab_5.task_4;
using System;

namespace Lab_5
{

    class Program
    {
        static void Main(string[] args)
        {
            task4();
        }


        static void task1()
        {
            Person person1 = new Person();

            person1.SetName("Bob");
            person1.SetAge(20);
            person1.SetGender("Male");
            person1.SetPhone("+12345");

            person1.Print();

            Console.WriteLine();

            Person person2 = new Person("Bliob", 22, "Female", "+54321");
            person2.Print();

            person2.SetAge(23);

            Console.WriteLine();
            person2.Print();
        }


        static void task2()
        {
            Student student = new Student("Bob", 3, 123);
            student.Print();
            Console.WriteLine();

            Aspirant aspirant = new Aspirant("Bliob", 5, 321, "Some topic");
            aspirant.Print();
            Console.WriteLine();

            aspirant.Course = 6;
            aspirant.DissertationTopic = "Soe another topic";
            aspirant.Print();
        }


        static void task3()
        {
            Book book1 = new Book("Book of Bob", "Bob", 450);
            book1.Print();

            Console.WriteLine();
            BookGenre book2 = new BookGenre("Book of Bliob", "Bliob", 370, "Fantasy");
            book2.Print();

            Console.WriteLine();
            BookGenrePubl book3 = new BookGenrePubl("Book of Bob and Bliob", "Bob and Bliob", 820, "Science fiction", "Bob and Bliob publishment");
            book3.Print();
        }


        static void task4()
        {
            Figure refFg;

            Rectangle rect = new Rectangle("Bob Rect", 1, 5, 6, 2);
            RectangleColor rectColor = new RectangleColor("Rect color", 2, 7, 8, 3, "green");

            refFg = rect;
            refFg.Display();
            Console.WriteLine();
            Console.WriteLine("Area: " + rect.Area());

            Console.WriteLine();

            refFg = rectColor;
            refFg.Display();
            Console.WriteLine();
            Console.WriteLine("Area: " + rectColor.Area());
        }
    }
}