namespace OOPTasks.Tests
{
    /// <summary>Завдання 2 — класи Student та Aspirant (успадкування, перевизначення Print).</summary>
    [TestFixture]
    public class StudentTests : ConsoleTestBase
    {
        [Test]
        public void Constructor_SetsAllProperties()
        {
            var student = new Student("Іваненко", 3, "КВ-12345");

            Assert.That(student.LastName, Is.EqualTo("Іваненко"));
            Assert.That(student.Course, Is.EqualTo(3));
            Assert.That(student.RecordBookNumber, Is.EqualTo("КВ-12345"));
        }

        [Test]
        public void Properties_CanBeChangedAfterCreation()
        {
            var student = new Student("Іваненко", 1, "КВ-1");

            student.LastName = "Сидоренко";
            student.Course = 2;
            student.RecordBookNumber = "КВ-2";

            Assert.That(student.LastName, Is.EqualTo("Сидоренко"));
            Assert.That(student.Course, Is.EqualTo(2));
            Assert.That(student.RecordBookNumber, Is.EqualTo("КВ-2"));
        }

        [Test]
        public void Print_Student_PrintsFormattedLine()
        {
            var student = new Student("Іваненко", 3, "КВ-12345");

            student.Print();

            Assert.That(ConsoleText, Is.EqualTo("Студент: Іваненко, Курс: 3, Заліковка: КВ-12345" + NL));
        }

        [Test]
        public void Aspirant_IsStudent()
        {
            var aspirant = new Aspirant("Петренко", 5, "АС-98765");

            Assert.That(aspirant, Is.InstanceOf<Student>());
        }

        [Test]
        public void Aspirant_Constructor_PassesValuesToBase()
        {
            var aspirant = new Aspirant("Петренко", 5, "АС-98765");

            Assert.That(aspirant.LastName, Is.EqualTo("Петренко"));
            Assert.That(aspirant.Course, Is.EqualTo(5));
            Assert.That(aspirant.RecordBookNumber, Is.EqualTo("АС-98765"));
        }

        [Test]
        public void Print_Aspirant_AddsPrefixToStudentLine()
        {
            var aspirant = new Aspirant("Петренко", 5, "АС-98765");

            aspirant.Print();

            Assert.That(ConsoleText, Is.EqualTo("[Аспірант] Студент: Петренко, Курс: 5, Заліковка: АС-98765" + NL));
        }

        [Test]
        public void Print_AspirantThroughStudentReference_UsesOverride()
        {
            Student student = new Aspirant("Петренко", 5, "АС-98765");

            student.Print();

            Assert.That(ConsoleText, Does.StartWith("[Аспірант] "));
        }
    }
}
