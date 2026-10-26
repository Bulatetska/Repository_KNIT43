namespace OOPTasks.Tests
{
    /// <summary>Завдання 3 — ієрархія Book → BookGenre → BookGenrePubl (sealed).</summary>
    [TestFixture]
    public class BookTests : ConsoleTestBase
    {
        [Test]
        public void Book_Constructor_SetsProperties()
        {
            var book = new Book("Кобзар", "Шевченко", 250.75);

            Assert.That(book.Title, Is.EqualTo("Кобзар"));
            Assert.That(book.Author, Is.EqualTo("Шевченко"));
            Assert.That(book.Price, Is.EqualTo(250.75).Within(1e-9));
        }

        [Test]
        public void Book_Print_PrintsTitleAuthorPrice()
        {
            var book = new Book("Кобзар", "Шевченко", 250.75);

            book.Print();

            Assert.That(ConsoleText, Is.EqualTo("Книга: 'Кобзар', Автор: Шевченко, Ціна: 250.75 грн" + NL));
        }

        [Test]
        public void BookGenre_Constructor_SetsOwnAndBaseProperties()
        {
            var book = new BookGenre("Тіні забутих предків", "Коцюбинський", 180, "Повість");

            Assert.That(book.Title, Is.EqualTo("Тіні забутих предків"));
            Assert.That(book.Author, Is.EqualTo("Коцюбинський"));
            Assert.That(book.Price, Is.EqualTo(180).Within(1e-9));
            Assert.That(book.Genre, Is.EqualTo("Повість"));
        }

        [Test]
        public void BookGenre_Print_AddsGenreLine()
        {
            var book = new BookGenre("Тіні забутих предків", "Коцюбинський", 180, "Повість");

            book.Print();

            Assert.That(ConsoleText, Is.EqualTo(
                "Книга: 'Тіні забутих предків', Автор: Коцюбинський, Ціна: 180 грн" + NL +
                "Жанр: Повість" + NL));
        }

        [Test]
        public void BookGenrePubl_Constructor_SetsAllProperties()
        {
            var book = new BookGenrePubl("Програмування на C#", "Троєлсен", 1500.50, "Навчальна література", "Вільямс");

            Assert.That(book.Title, Is.EqualTo("Програмування на C#"));
            Assert.That(book.Author, Is.EqualTo("Троєлсен"));
            Assert.That(book.Price, Is.EqualTo(1500.50).Within(1e-9));
            Assert.That(book.Genre, Is.EqualTo("Навчальна література"));
            Assert.That(book.Publisher, Is.EqualTo("Вільямс"));
        }

        [Test]
        public void BookGenrePubl_Print_PrintsThreeLinesInOrder()
        {
            var book = new BookGenrePubl("Програмування на C#", "Троєлсен", 1500.50, "Навчальна література", "Вільямс");

            book.Print();

            Assert.That(ConsoleText, Is.EqualTo(
                "Книга: 'Програмування на C#', Автор: Троєлсен, Ціна: 1500.5 грн" + NL +
                "Жанр: Навчальна література" + NL +
                "Видавець: Вільямс" + NL));
        }

        [Test]
        public void BookGenrePubl_IsSealed()
        {
            Assert.That(typeof(BookGenrePubl).IsSealed, Is.True);
        }

        [Test]
        public void BookGenrePubl_InheritsWholeHierarchy()
        {
            var book = new BookGenrePubl("A", "B", 1, "C", "D");

            Assert.That(book, Is.InstanceOf<BookGenre>());
            Assert.That(book, Is.InstanceOf<Book>());
        }

        [Test]
        public void Print_ThroughBookReference_CallsMostDerivedOverride()
        {
            Book book = new BookGenrePubl("A", "B", 10, "C", "D");

            book.Print();

            Assert.That(ConsoleText, Does.Contain("Жанр: C"));
            Assert.That(ConsoleText, Does.Contain("Видавець: D"));
        }
    }
}
