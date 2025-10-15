using Xunit;
using Lab4Classes;

namespace Lab4.Tests
{
    public class UnitTestFull
    {
        // 1. Person
        [Fact]
        public void Person_SetAndPrint_Works()
        {
            var p = new Person();
            p.SetName("Katya");
            p.SetAge(20);
            p.SetGender("Female");
            p.SetPhone("+380123456789");

            Assert.Equal("Katya", p.Name);
            Assert.Equal(20, p.Age);
            Assert.Equal("Female", p.Gender);
            Assert.Equal("+380123456789", p.PhoneNumber);
        }

        // 2. Student
        [Fact]
        public void Student_ConstructorsAndPrint_Works()
        {
            var s = new Student("Petrenko", 3, "12345");
            Assert.Equal("Petrenko", s.LastName);
            Assert.Equal(3, s.Course);
            Assert.Equal("12345", s.RecordBook);
        }

        // 3. Aspirant
        [Fact]
        public void Aspirant_ConstructorsAndPrint_Works()
        {
            var a = new Aspirant("Ivanenko", 5, "67890", "Philosophy");
            Assert.Equal("Ivanenko", a.LastName);
            Assert.Equal(5, a.Course);
            Assert.Equal("67890", a.RecordBook);
            Assert.Equal("Philosophy", a.DissertationTopic);
        }

        // 4. Book
        [Fact]
        public void Book_ConstructorsAndPrint_Works()
        {
            var b = new Book("Kim Ji-young. Born 1982", "Cho Nam-Joo", 220);
            Assert.Equal("Kim Ji-young. Born 1982", b.Title);
            Assert.Equal("Cho Nam-Joo", b.Author);
            Assert.Equal(220, b.Price);
        }

        // 5. BookGenre
        [Fact]
        public void BookGenre_ConstructorsAndPrint_Works()
        {
            var bg = new BookGenre("Four Treasures", "Jenny Zhang", 550, "Novel");
            Assert.Equal("Four Treasures", bg.Title);
            Assert.Equal("Jenny Zhang", bg.Author);
            Assert.Equal(550, bg.Price);
            Assert.Equal("Novel", bg.Genre);
        }

        // 6. BookGenrePubl
        [Fact]
        public void BookGenrePubl_ConstructorsAndPrint_Works()
        {
            var bgp = new BookGenrePubl("C# Pro", "Mike Johnson", 600, "IT", "Oxford Press");
            Assert.Equal("C# Pro", bgp.Title);
            Assert.Equal("Mike Johnson", bgp.Author);
            Assert.Equal(600, bgp.Price);
            Assert.Equal("IT", bgp.Genre);
            Assert.Equal("Oxford Press", bgp.Publisher);
        }

        // 7. Rectangle
        [Fact]
        public void Rectangle_ConstructorsAndArea_Works()
        {
            var r = new Rectangle("Rect", 2, 3, 5, 5);
            Assert.Equal("Rect", r.Name);
            Assert.Equal(2, r.X1);
            Assert.Equal(3, r.Y1);
            Assert.Equal(5, r.X2);
            Assert.Equal(5, r.Y2);
            Assert.Equal(6, r.Area()); // (5-2)*(5-3) = 3*2 = 6
        }

        // 8. RectangleColor
        [Fact]
        public void RectangleColor_ConstructorsAndArea_Works()
        {
            var rc = new RectangleColor("RectColor", 0, 0, 5, 10, "Red");
            Assert.Equal("RectColor", rc.Name);
            Assert.Equal(0, rc.X1);
            Assert.Equal(0, rc.Y1);
            Assert.Equal(5, rc.X2);
            Assert.Equal(10, rc.Y2);
            Assert.Equal("Red", rc.Color);
            Assert.Equal(50, rc.Area()); // (5-0)*(10-0) = 50
        }

        // 9. Figure
        [Fact]
        public void Figure_ConstructorsAndDisplay_Works()
        {
            var f = new Figure("Generic");
            Assert.Equal("Generic", f.Name);
        }

        // 10. Rectangle as Figure
        [Fact]
        public void Rectangle_AsFigure_Polymorphism_Works()
        {
            Figure f = new Rectangle("PolyRect", 1, 1, 4, 5);
            Assert.Equal("PolyRect", f.Name);
            Assert.IsType<Rectangle>(f);
        }

        // 11. RectangleColor as Figure
        [Fact]
        public void RectangleColor_AsFigure_Polymorphism_Works()
        {
            Figure f = new RectangleColor("PolyRectColor", 0, 0, 2, 5, "Blue");
            Assert.Equal("PolyRectColor", f.Name);
            Assert.IsType<RectangleColor>(f);
        }
    }
}
