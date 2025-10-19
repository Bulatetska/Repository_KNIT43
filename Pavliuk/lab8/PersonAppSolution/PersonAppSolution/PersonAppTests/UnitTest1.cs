using NUnit.Framework;
using PersonApp;

namespace PersonAppTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class PersonTests
    {
        [Test]
        public void SetName_ShouldUpdateName()
        {
            // Arrange
            Person p = new Person();
            // Act
            p.SetName("Oksana");
            // Assert
            Assert.AreEqual("Oksana", p.name);
        }

        [Test]
        public void SetAge_ShouldUpdateAge()
        {
            // Arrange
            Person p = new Person();
            // Act
            p.SetAge(19);
            // Assert
            Assert.AreEqual(19, p.age);
        }

        [Test]
        public void SetSex_ShouldUpdateSex()
        {
            // Arrange
            Person p = new Person();
            // Act
            p.SetSex("woman");
            // Assert
            Assert.AreEqual("woman", p.sex);
        }

        [Test]
        public void SetPhone_ShouldUpdatePhone()
        {
            // Arrange
            Person p = new Person();
            // Act
            p.SetPhone("+38026655423");
            // Assert
            Assert.AreEqual("+38026655423", p.phone_number);
        }
    }

    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void SetSurname_ShouldUpdateSurname()
        {
            // Arrange
            Student s = new Student();
            // Act
            s.SetSurname("Pavliuk");
            // Assert
            Assert.AreEqual("Pavliuk", s.GetSurname());
        }

        [Test]
        public void SetKurs_ShouldUpdateKurs()
        {
            // Arrange
            Student s = new Student();
            // Act
            s.SetKurs(4);
            // Assert
            Assert.AreEqual(4, s.GetKurs());
        }

        [Test]
        public void SetNumber_ShouldUpdateNumber()
        {
            // Arrange
            Student s = new Student();
            // Act
            s.SetNumber(22052);
            // Assert
            Assert.AreEqual(22052, s.GetNumberZalikovky());
        }

        [Test]
        public void Constructor_ShouldInitializeDefaultValues()
        {
            // Arrange
            // Act
            Student s = new Student();
            // Assert
            Assert.AreEqual("", s.GetSurname());
            Assert.AreEqual(0, s.GetKurs());
            Assert.AreEqual(0, s.GetNumberZalikovky());
        }

        [Test]
        public void ConstructorWithParameters_ShouldInitializeProperties()
        {
            // Arrange
            // Act
            Student s = new Student("Pavliuk", 4, 22052);
            Assert.AreEqual("Pavliuk", s.GetSurname());
            // Assert
            Assert.AreEqual(4, s.GetKurs());
            Assert.AreEqual(22052, s.GetNumberZalikovky());
        }
    }

    [TestFixture]
    public class AspirantTests
    {
        [Test]
        public void Constructor_ShouldSetAllProperties()
        {
            // Arrange
            // Act
            Aspirant a = new Aspirant("Anna", 1, 220252, "MyDissertation");
            // Assert
            Assert.AreEqual("Anna", a.surname);      
            Assert.AreEqual(1, a.kurs);
            Assert.AreEqual(220252, a.number_zalikovky);
            Assert.AreEqual("MyDissertation", a.Dissertation);
        }
    }
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            // Act
            Book b = new Book("Moonknight", "A.A.Smilam", 250);
            // Assert
            Assert.AreEqual("Moonknight", b.title);
            Assert.AreEqual("A.A.Smilam", b.surname_name);
            Assert.AreEqual(250, b.price);
        }
    }

    [TestFixture]
    public class BookGenrePublTests
    {
        [Test]
        public void Constructor_ShouldCreateObjectWithAllFields()
        {
            // Arrange
            // Act
            BookGenrePubl bp = new BookGenrePubl("Moonknight", "A.A.Smilam", 250, "romcom", "Pajak");
            // Assert
            Assert.DoesNotThrow(() => bp.Print());
        }
    }

    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void Area_ShouldReturnCorrectArea()
        {
            // Act
            Rectangle r = new Rectangle("Rect", 2, 5, 3, 7); 
            int expectedArea = (5 - 2) * (7 - 3);
            // Assert
            Assert.AreEqual(expectedArea, r.Area());
        }
    }

    [TestFixture]
    public class RectangleColorTests
    {
        [Test]
        public void Constructor_ShouldSetColorAndProperties()
        {
            // Act
            RectangleColor rc = new RectangleColor("Red", "Rect", 0, 1, 0, 2);
            // Assert
            Assert.AreEqual("Red", rc.color);
            Assert.AreEqual(1, rc.x2);
            Assert.AreEqual(2, rc.y2);
        }

        [Test]
        public void Area_ShouldReturnCorrectArea()
        {
            // Act
            RectangleColor rc = new RectangleColor("Red", "Rect", 0, 3, 0, 4);
            int expectedArea = (3 - 0) * (4 - 0);
            // Assert
            Assert.AreEqual(expectedArea, rc.Area());
        }
    }
}
