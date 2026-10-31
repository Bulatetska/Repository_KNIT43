using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ClassesLab.Tests;
[TestClass] public class FigureTests
{
    [TestMethod] public void Figure_Constructor_SetsName() { var f = new Figure("Фігура"); Assert.AreEqual("Фігура", f.Name); }
    [TestMethod] public void Figure_Display_ShowsName() { var output = TestHelpers.Capture(() => new Figure("Тест").Display()); StringAssert.Contains(output, "Тест"); }
    [TestMethod] public void Figure_Reference_InvokesRectangleOverride() { Figure f = new Rectangle("Прямокутник", 0, 0, 2, 3); var output = TestHelpers.Capture(f.Display); StringAssert.Contains(output, "Координати:"); }
    [TestMethod] public void Figure_Reference_InvokesColoredOverride() { Figure f = new RectangleColor("Фігура", 0, 0, 2, 3, "Синій"); var output = TestHelpers.Capture(f.Display); StringAssert.Contains(output, "Колір: Синій"); }
}
