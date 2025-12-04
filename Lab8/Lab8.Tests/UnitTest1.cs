using NUnit.Framework;
using OOP_Tasks;

namespace Lab8.Tests
{
    public class Tests
    {
        [Test]
        public void Rectangle_Area_Correct()
        {
            var rect = new Rectangle("Test", 0, 0, 3, 4);

            double area = rect.Area();

            Assert.AreEqual(12, area);
        }

        [Test]
        public void Person_Properties_Work()
        {
            var p = new Person("Oleg", 20, "male", "12345");

            Assert.AreEqual("Oleg", p.Name);
            Assert.AreEqual(20, p.Age);
            Assert.AreEqual("male", p.Gender);
            Assert.AreEqual("12345", p.Phone);
        }

        [Test]
        public void Person_Name_Can_Change()
        {
            var p = new Person("Oleg", 20, "male", "12345");
            p.Name = "Ivan";

            Assert.AreEqual("Ivan", p.Name);
        }
    }
}

