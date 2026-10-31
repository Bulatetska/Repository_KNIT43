using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class BookGenreTests
{
    [TestMethod] public void BookGenre_Constructor_SetsInheritedAndGenre() { var b = Make(); Assert.AreEqual("Роман", b.Title); Assert.AreEqual("Автор", b.Author); Assert.AreEqual(320m, b.Price); Assert.AreEqual("Фантастика", b.Genre); }
    [TestMethod] public void BookGenre_SetGenre_ChangesGenre() { var b = Make(); b.Genre = "Драма"; Assert.AreEqual("Драма", b.Genre); }
    [TestMethod] public void BookGenre_Print_IncludesGenreAndBaseDetails() { var output = TestHelpers.Capture(() => Make().Print()); StringAssert.Contains(output, "Роман"); StringAssert.Contains(output, "Фантастика"); }
    private static BookGenre Make() => new("Роман", "Автор", 320m, "Фантастика");
}
