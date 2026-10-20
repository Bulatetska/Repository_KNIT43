using NUnit.Framework;
using System;
using System.IO;

namespace MyClassesTests
{
    [TestFixture]
    public class UnitTest1
    {
        // Допоміжний метод для перехоплення виведення в консоль
        private static string CaptureConsole(Action action)
        {
            TextWriter originalOutput = Console.Out;

            using var writer = new StringWriter();

            try
            {
                Console.SetOut(writer);
                action();
            }
            finally
            {
                Console.SetOut(originalOutput);
            }

            return writer.ToString();
        }

        // =====================================
        // ЗАВДАННЯ 1. PERSON
        // =====================================

        [Test]
        public void Person_Constructor_SetsProperties()
        {
            var person = new global::Person(
                "Андрій", 20, "Чоловіча", "123456789");

            Assert.That(person.Name, Is.EqualTo("Андрій"));
            Assert.That(person.Age, Is.EqualTo(20));
            Assert.That(person.Gender, Is.EqualTo("Чоловіча"));
            Assert.That(person.PhoneNumber, Is.EqualTo("123456789"));
        }

        [Test]
        public void Person_SetMethods_ChangeProperties()
        {
            var person = new global::Person(
                "Андрій", 20, "Чоловіча", "111");

            person.SetName("Олег");
            person.SetAge(21);
            person.SetGender("Чоловіча");
            person.SetPhoneNumber("222");

            Assert.That(person.Name, Is.EqualTo("Олег"));
            Assert.That(person.Age, Is.EqualTo(21));
            Assert.That(person.Gender, Is.EqualTo("Чоловіча"));
            Assert.That(person.PhoneNumber, Is.EqualTo("222"));
        }

        [Test]
        public void Person_Print_DisplaysInformation()
        {
            var person = new global::Person(
                "Андрій", 20, "Чоловіча", "123");

            string output = CaptureConsole(person.Print);

            Assert.That(output, Does.Contain("Ім'я: Андрій"));
            Assert.That(output, Does.Contain("Вік: 20"));
            Assert.That(output, Does.Contain("Стать: Чоловіча"));
            Assert.That(output, Does.Contain("Телефон: 123"));
        }

        // =====================================
        // ЗАВДАННЯ 2. STUDENT ТА ASPIRANT
        // =====================================

        [Test]
        public void Student_Print_DisplaysInformation()
        {
            var student = new global::Student(
                "Петренко", 3, "KN-12345");

            string output = CaptureConsole(student.Print);

            Assert.That(output, Does.Contain("Прізвище: Петренко"));
            Assert.That(output, Does.Contain("Курс навчання: 3"));
            Assert.That(output, Does.Contain(
                "Номер залікової книжки: KN-12345"));
        }

        [Test]
        public void Aspirant_Print_DisplaysStudentAndDissertation()
        {
            var aspirant = new global::Aspirant(
                "Іваненко", 5, "AS-54321", "Штучний інтелект");

            string output = CaptureConsole(aspirant.Print);

            Assert.That(output, Does.Contain("Прізвище: Іваненко"));
            Assert.That(output, Does.Contain("Курс навчання: 5"));
            Assert.That(output, Does.Contain(
                "Номер залікової книжки: AS-54321"));
            Assert.That(output, Does.Contain(
                "Тема дисертації: Штучний інтелект"));
        }

        // =====================================
        // ЗАВДАННЯ 3. BOOK
        // =====================================

        [Test]
        public void Book_Print_DisplaysBookInformation()
        {
            var book = new global::Book(
                "Основи програмування",
                "Іван Петренко",
                350.50m);

            string output = CaptureConsole(book.Print);

            Assert.That(output, Does.Contain("Основи програмування"));
            Assert.That(output, Does.Contain("Іван Петренко"));
            Assert.That(output, Does.Contain("Вартість:"));
            Assert.That(output, Does.Contain("350"));
            Assert.That(output, Does.Contain("грн"));
        }

        [Test]
        public void BookGenre_Print_DisplaysGenre()
        {
            var book = new global::BookGenre(
                "Таємниці Всесвіту",
                "Олена Коваль",
                420.00m,
                "Науково-популярна література");

            string output = CaptureConsole(book.Print);

            Assert.That(output, Does.Contain("Таємниці Всесвіту"));
            Assert.That(output, Does.Contain(
                "Жанр: Науково-популярна література"));
        }

        [Test]
        public void BookGenrePubl_Print_DisplaysPublisher()
        {
            var book = new global::BookGenrePubl(
                "Пригоди мандрівника",
                "Максим Шевченко",
                275.90m,
                "Пригоди",
                "Видавництво Світ");

            string output = CaptureConsole(book.Print);

            Assert.That(output, Does.Contain("Пригоди мандрівника"));
            Assert.That(output, Does.Contain("Жанр: Пригоди"));
            Assert.That(output, Does.Contain(
                "Видавництво: Видавництво Світ"));
        }

        // =====================================
        // ЗАВДАННЯ 4. FIGURE ТА RECTANGLE
        // =====================================

        [Test]
        public void Figure_Display_DisplaysName()
        {
            var figure = new global::Figure("Моя фігура");

            string output = CaptureConsole(figure.Display);

            Assert.That(output, Does.Contain(
                "Назва фігури: Моя фігура"));
        }

        [Test]
        public void Rectangle_Area_ReturnsCorrectValue()
        {
            var rectangle = new global::Rectangle(
                "Прямокутник", 2, 3, 8, 7);

            double result = rectangle.Area();

            Assert.That(result, Is.EqualTo(24.0).Within(0.0001));
        }

        [Test]
        public void Rectangle_Display_DisplaysCoordinates()
        {
            var rectangle = new global::Rectangle(
                "Прямокутник", 2, 3, 8, 7);

            string output = CaptureConsole(rectangle.Display);

            Assert.That(output, Does.Contain(
                "Назва фігури: Прямокутник"));
            Assert.That(output, Does.Contain(
                "Лівий верхній кут: (2; 3)"));
            Assert.That(output, Does.Contain(
                "Правий нижній кут: (8; 7)"));
        }

        [Test]
        public void Rectangle_DefaultConstructor_CreatesUnitRectangle()
        {
            var rectangle = new global::Rectangle();

            Assert.That(rectangle.Name, Is.EqualTo("Прямокутник"));
            Assert.That(
                rectangle.Area(), Is.EqualTo(1.0).Within(0.0001));
        }

        // =====================================
        // RECTANGLECOLOR
        // =====================================

        [Test]
        public void RectangleColor_Area_ReturnsCorrectValue()
        {
            var rectangle = new global::RectangleColor(
                "Кольоровий прямокутник",
                1, 1, 5, 4, "Синій");

            double result = rectangle.Area();

            Assert.That(result, Is.EqualTo(12.0).Within(0.0001));
        }

        [Test]
        public void RectangleColor_Display_DisplaysColor()
        {
            var rectangle = new global::RectangleColor(
                "Кольоровий прямокутник",
                1, 1, 5, 4, "Синій");

            string output = CaptureConsole(rectangle.Display);

            Assert.That(output, Does.Contain(
                "Назва фігури: Кольоровий прямокутник"));
            Assert.That(output, Does.Contain("Колір: Синій"));
        }

        [Test]
        public void RectangleColor_DefaultConstructor_CreatesDefaultValues()
        {
            var rectangle = new global::RectangleColor();

            Assert.That(
                rectangle.Name,
                Is.EqualTo("Кольоровий прямокутник"));
            Assert.That(rectangle.Color, Is.EqualTo("Червоний"));
            Assert.That(
                rectangle.Area(), Is.EqualTo(1.0).Within(0.0001));
        }
    }
}