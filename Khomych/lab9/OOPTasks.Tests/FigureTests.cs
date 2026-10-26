namespace OOPTasks.Tests
{
    /// <summary>Завдання 4 — Figure → Rectangle → RectangleColor (конструктори, Display, Area, поліморфізм).</summary>
    [TestFixture]
    public class FigureTests : ConsoleTestBase
    {
        // ---------- Figure ----------

        [Test]
        public void Figure_Constructor_SetsName()
        {
            var figure = new Figure("Коло");

            Assert.That(figure.Name, Is.EqualTo("Коло"));
        }

        [Test]
        public void Figure_Display_PrintsName()
        {
            var figure = new Figure("Коло");

            figure.Display();

            Assert.That(ConsoleText, Is.EqualTo("Фігура: Коло" + NL));
        }

        // ---------- Rectangle ----------

        [Test]
        public void Rectangle_Constructor_SetsNameAndCoordinates()
        {
            var rect = new Rectangle("Мій Прямокутник", 1, 5, 4, 1);

            Assert.That(rect.Name, Is.EqualTo("Мій Прямокутник"));
            Assert.That(rect.X1, Is.EqualTo(1));
            Assert.That(rect.Y1, Is.EqualTo(5));
            Assert.That(rect.X2, Is.EqualTo(4));
            Assert.That(rect.Y2, Is.EqualTo(1));
        }

        [Test]
        public void Rectangle_DefaultConstructor_SetsDefaultValues()
        {
            var rect = new Rectangle();

            Assert.That(rect.Name, Is.EqualTo("Прямокутник (за замовчуванням)"));
            Assert.That(rect.X1, Is.EqualTo(0));
            Assert.That(rect.Y1, Is.EqualTo(0));
            Assert.That(rect.X2, Is.EqualTo(1));
            Assert.That(rect.Y2, Is.EqualTo(1));
        }

        [TestCase(1, 5, 4, 1, 12)]      // приклад з Main
        [TestCase(4, 1, 1, 5, 12)]      // точки у зворотному порядку
        [TestCase(0, 0, 1, 1, 1)]       // одиничний квадрат
        [TestCase(-2, -3, 2, 3, 24)]    // від'ємні координати
        [TestCase(0, 0, 1.5, 2, 3)]     // дробові сторони
        [TestCase(2, 2, 2, 7, 0)]       // нульова ширина
        [TestCase(3, 3, 3, 3, 0)]       // вироджений (точка)
        public void Rectangle_Area_ReturnsAbsoluteWidthTimesHeight(
            double x1, double y1, double x2, double y2, double expected)
        {
            var rect = new Rectangle("R", x1, y1, x2, y2);

            Assert.That(rect.Area(), Is.EqualTo(expected).Within(1e-9));
        }

        [Test]
        public void Rectangle_Area_IsNeverNegative()
        {
            var rect = new Rectangle("R", 10, 10, -5, -5);

            Assert.That(rect.Area(), Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Rectangle_Area_RecalculatesAfterCoordinatesChange()
        {
            var rect = new Rectangle();   // площа 1

            rect.X2 = 3;
            rect.Y2 = 4;

            Assert.That(rect.Area(), Is.EqualTo(12).Within(1e-9));
        }

        [Test]
        public void Rectangle_Display_PrintsNameAndCoordinates()
        {
            var rect = new Rectangle("Мій Прямокутник", 1, 5, 4, 1);

            rect.Display();

            Assert.That(ConsoleText, Is.EqualTo(
                "Фігура: Мій Прямокутник" + NL +
                "Координати: (1;5), (4;1)" + NL));
        }

        [Test]
        public void Rectangle_IsFigure()
        {
            Assert.That(new Rectangle(), Is.InstanceOf<Figure>());
        }

        // ---------- RectangleColor ----------

        [Test]
        public void RectangleColor_Constructor_SetsAllProperties()
        {
            var rect = new RectangleColor("Червоний Прямокутник", 0, 10, 5, 0, "Червоний");

            Assert.That(rect.Name, Is.EqualTo("Червоний Прямокутник"));
            Assert.That(rect.X1, Is.EqualTo(0));
            Assert.That(rect.Y1, Is.EqualTo(10));
            Assert.That(rect.X2, Is.EqualTo(5));
            Assert.That(rect.Y2, Is.EqualTo(0));
            Assert.That(rect.Color, Is.EqualTo("Червоний"));
        }

        [Test]
        public void RectangleColor_DefaultConstructor_SetsDefaultValues()
        {
            var rect = new RectangleColor();

            Assert.That(rect.Name, Is.EqualTo("Кольоровий прямокутник (за замовчуванням)"));
            Assert.That(rect.X1, Is.EqualTo(0));
            Assert.That(rect.Y1, Is.EqualTo(0));
            Assert.That(rect.X2, Is.EqualTo(1));
            Assert.That(rect.Y2, Is.EqualTo(1));
            Assert.That(rect.Color, Is.EqualTo("Чорний"));
        }

        [Test]
        public void RectangleColor_Area_EqualsRectangleArea()
        {
            var colored = new RectangleColor("C", 0, 10, 5, 0, "Червоний");
            var plain = new Rectangle("P", 0, 10, 5, 0);

            Assert.That(colored.Area(), Is.EqualTo(50).Within(1e-9));
            Assert.That(colored.Area(), Is.EqualTo(plain.Area()).Within(1e-9));
        }

        [Test]
        public void RectangleColor_Display_PrintsThreeLinesInOrder()
        {
            var rect = new RectangleColor("Червоний Прямокутник", 0, 10, 5, 0, "Червоний");

            rect.Display();

            Assert.That(ConsoleText, Is.EqualTo(
                "Фігура: Червоний Прямокутник" + NL +
                "Координати: (0;10), (5;0)" + NL +
                "Колір: Червоний" + NL));
        }

        [Test]
        public void RectangleColor_InheritsWholeHierarchy()
        {
            var rect = new RectangleColor();

            Assert.That(rect, Is.InstanceOf<Rectangle>());
            Assert.That(rect, Is.InstanceOf<Figure>());
        }

        // ---------- Поліморфізм через посилання на базовий клас (як у Main) ----------

        [Test]
        public void Display_ThroughFigureReference_CallsRectangleOverride()
        {
            Figure figRef = new Rectangle("R", 1, 5, 4, 1);

            figRef.Display();

            Assert.That(ConsoleText, Does.Contain("Координати: (1;5), (4;1)"));
        }

        [Test]
        public void Display_ThroughFigureReference_CallsRectangleColorOverride()
        {
            Figure figRef = new RectangleColor("C", 0, 10, 5, 0, "Червоний");

            figRef.Display();

            Assert.That(ConsoleText, Does.Contain("Колір: Червоний"));
        }

        [Test]
        public void Area_ThroughRectangleReference_WorksForRectangleColor()
        {
            Rectangle rectRef = new RectangleColor("C", 0, 10, 5, 0, "Червоний");

            Assert.That(rectRef.Area(), Is.EqualTo(50).Within(1e-9));
        }
    }
}
