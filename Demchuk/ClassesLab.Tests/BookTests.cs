using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class BookTests
{
    [TestMethod] public void Book_Constructor_SetsProperties() { var b = Make(); Assert.AreEqual("Кобзар", b.Title); Assert.AreEqual("Тарас Шевченко", b.Author); Assert.AreEqual(250m, b.Price); }
    [TestMethod] public void Book_Setters_UpdateProperties() { var b = Make(); b.Title = "Нова книга"; b.Author = "Автор"; b.Price = 100m; Assert.AreEqual("Нова книга", b.Title); Assert.AreEqual("Автор", b.Author); Assert.AreEqual(100m, b.Price); }
    [TestMethod] public void Book_Print_ShowsBookData() { string output = TestHelpers.Capture(() => Make().Print()); StringAssert.Contains(output, "Кобзар"); StringAssert.Contains(output, "Тарас Шевченко"); StringAssert.Contains(output, "250"); }
    private static Book Make() => new("Кобзар", "Тарас Шевченко", 250m);
}
