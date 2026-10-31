using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class BookGenrePublTests
{
    [TestMethod] public void BookGenrePubl_Constructor_SetsAllProperties() { var b = Make(); Assert.AreEqual("Роман", b.Title); Assert.AreEqual("Автор", b.Author); Assert.AreEqual(300m, b.Price); Assert.AreEqual("Драма", b.Genre); Assert.AreEqual("Веселка", b.Publisher); }
    [TestMethod] public void BookGenrePubl_PublisherSetter_ChangesPublisher() { var b = Make(); b.Publisher = "Ранок"; Assert.AreEqual("Ранок", b.Publisher); }
    [TestMethod] public void BookGenrePubl_Print_IncludesPublisher() { var output = TestHelpers.Capture(() => Make().Print()); StringAssert.Contains(output, "Роман"); StringAssert.Contains(output, "Драма"); StringAssert.Contains(output, "Веселка"); }
    [TestMethod] public void BookGenrePubl_Class_IsSealed() => Assert.IsTrue(typeof(BookGenrePubl).IsSealed);
    private static BookGenrePubl Make() => new("Роман", "Автор", 300m, "Драма", "Веселка");
}
