namespace OOPTasks.Tests
{
    /// <summary>Завдання 1 — клас Person (закриті поля + функції-члени для їх зміни).</summary>
    [TestFixture]
    public class PersonTests : ConsoleTestBase
    {
        [Test]
        public void Print_AfterAllSetters_PrintsAllData()
        {
            var person = new Person();
            person.SetName("Олександр");
            person.SetAge(30);
            person.SetGender("Чоловіча");
            person.SetPhone("+380991234567");

            person.Print();

            Assert.That(ConsoleText, Is.EqualTo(
                "Особа: Ім'я: Олександр, Вік: 30, Стать: Чоловіча, Телефон: +380991234567" + NL));
        }

        [Test]
        public void Print_NewPerson_PrintsDefaultValues()
        {
            var person = new Person();

            person.Print();

            Assert.That(ConsoleText, Is.EqualTo("Особа: Ім'я: , Вік: 0, Стать: , Телефон: " + NL));
        }

        [Test]
        public void SetName_ChangesOnlyName()
        {
            var person = new Person();
            person.SetName("Ірина");
            person.SetAge(25);

            person.SetName("Марія");
            person.Print();

            Assert.That(ConsoleText, Does.Contain("Ім'я: Марія"));
            Assert.That(ConsoleText, Does.Not.Contain("Ірина"));
            Assert.That(ConsoleText, Does.Contain("Вік: 25"));
        }

        [TestCase(0)]
        [TestCase(18)]
        [TestCase(99)]
        public void SetAge_StoresGivenAge(int age)
        {
            var person = new Person();

            person.SetAge(age);
            person.Print();

            Assert.That(ConsoleText, Does.Contain($"Вік: {age},"));
        }

        [Test]
        public void SetGender_StoresGender()
        {
            var person = new Person();

            person.SetGender("Жіноча");
            person.Print();

            Assert.That(ConsoleText, Does.Contain("Стать: Жіноча"));
        }

        [Test]
        public void SetPhone_StoresPhone()
        {
            var person = new Person();

            person.SetPhone("+380501112233");
            person.Print();

            Assert.That(ConsoleText, Does.Contain("Телефон: +380501112233"));
        }

        [Test]
        public void SetPhone_CalledTwice_KeepsLastValue()
        {
            var person = new Person();

            person.SetPhone("111");
            person.SetPhone("222");
            person.Print();

            Assert.That(ConsoleText, Does.Contain("Телефон: 222"));
            Assert.That(ConsoleText, Does.Not.Contain("111"));
        }
    }
}
