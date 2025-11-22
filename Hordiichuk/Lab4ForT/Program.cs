// Lab4ForT/Program.cs
using System;

namespace Lab4ForT
{
    class Program
    {
        static void Main()
        {
            // 1. Person
            Console.WriteLine("=== Person ===");
            var person = new Person("Viktoriia", 20, "Female", "+380 000 0000");
            Console.WriteLine($"{person.Name}, Age: {person.Age}, Gender: {person.Gender}, Phone: {person.Phone}");
            person.Age = 26;
            Console.WriteLine($"{person.Name}, Age: {person.Age}, Gender: {person.Gender}, Phone: {person.Phone}");

            // 2. Student / Aspirant
            Console.WriteLine("\n=== Student & Aspirant ===");
            var student = new Student("Lawrence", 3, "AB123");
            Console.WriteLine($"{student.Surname}, Course: {student.Course}, RecordBook: {student.RecordBook}");

            var aspirant = new Aspirant("Shmidt", 5, "XY789", "System Programming");
            Console.WriteLine($"{aspirant.Surname}, Course: {aspirant.Course}, RecordBook: {aspirant.RecordBook}, Topic: {aspirant.DissertationTopic}");

            // 3. Books
            Console.WriteLine("\n=== Books ===");
            var book = new Book("Shutter Island", "Dennis Lehane", 350);
            Console.WriteLine($"{book.Title} by {book.Author}, Price: {book.Price} UAH");

            var bookGenre = new BookGenre("One Hundred Names", "Cecelia Ahern", 400, "Fiction");
            Console.WriteLine($"{bookGenre.Title} ({bookGenre.Genre}) by {bookGenre.Author}, Price: {bookGenre.Price} UAH");

            var bookGenrePubl = new BookGenrePubl("Given", "Natsuki Kizu", 240, "Manga", "ТАК");
            Console.WriteLine($"{bookGenrePubl.Title} ({bookGenrePubl.Genre}) by {bookGenrePubl.Author}, Publisher: {bookGenrePubl.Publisher}, Price: {bookGenrePubl.Price} UAH");

            // 4. Figures
            Console.WriteLine("\n=== Figures ===");

            Rectangle rect = new Rectangle("MyRect", 2, 2, 6, 5);
            Console.WriteLine($"{rect.Name}: Coordinates ({rect.X1},{rect.Y1}) - ({rect.X2},{rect.Y2}), Area = {rect.Area()}");

            RectangleColor rectColor = new RectangleColor("ColoredRect", 0, 0, 4, 3, "blue");
            Console.WriteLine($"{rectColor.Name}: Coordinates ({rectColor.X1},{rectColor.Y1}) - ({rectColor.X2},{rectColor.Y2}), Color = {rectColor.Color}, Area = {rectColor.Area()}");

            Console.WriteLine("\n=== Demo Complete ===");
        }
    }
}
