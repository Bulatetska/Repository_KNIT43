// Підключення бібліотеки NUnit для модульного тестування
using NUnit.Framework;

// Простір імен для тестів, пов'язаних з векторами
namespace Lab6
{
    // Атрибут, що позначає клас як тестовий клас (test fixture)
    [TestFixture]
    // Дозволяє паралельне виконання тестів для підвищення швидкості
    [Parallelizable(ParallelScope.All)]
    class VectorTests
    {
        // Тест для перевірки операції негації (зміни знаку) вектора
        [Test]
        public void Negate()
        {
            // Створення вектора з координатами (3, -4.5)
            var a = new Vector(3, -4.5);
            var result = -a;

            
            Assert.That(result.X, Is.EqualTo(-a.X));
            Assert.That(result.Y, Is.EqualTo(-a.Y));
        }

        // Тест для перевірки операції додавання векторів
        [Test]
        public void Add()
        {
            var a = new Vector(2, 4);
            var b = new Vector(1, -1);
            var result = a + b;

            // Перевірка, що X-координата результату дорівнює сумі X-координат
            Assert.That(result.X, Is.EqualTo(a.X + b.X));
            Assert.That(result.Y, Is.EqualTo(a.Y + b.Y));
        }

        // Тест для перевірки операції порівняння на рівність
        [Test]
        public void Equals()
        {
            // Створення трьох векторів для тестування
            var a = new Vector(2, 4);
            var b = new Vector(1, -1);
            var c = new Vector(2, 4);  // Такий самий як a

            // Перевірка, що різні вектори не рівні
            Assert.That(a == b, Is.False);
            // Перевірка, що однакові вектори рівні
            Assert.That(a == c, Is.True);
        }

        // Тест для перевірки операції порівняння на нерівність
        [Test]
        public void NotEquals()
        {
            // Створення трьох векторів для тестування
            var a = new Vector(2, 4);
            var b = new Vector(1, -1);
            var c = new Vector(2, 4);  // Такий самий як a

            // Перевірка, що різні вектори нерівні
            Assert.That(a != b, Is.True);
            // Перевірка, що однакові вектори не нерівні
            Assert.That(a != c, Is.False);
        }

        // Тест для перевірки операції множення вектора на скаляр
        [Test]
        public void Multiply()
        {
            // Створення вектора з координатами (2, 4)
            var a = new Vector(2, 4);
            // Створення скаляра для множення
            var b = 3;
            // Виконання множення вектора на скаляр
            var result = a * b;

            // Перевірка, що X-координата результату дорівнює X вектора помноженому на скаляр
            Assert.That(result.X, Is.EqualTo(a.X * b));
            // Перевірка, що Y-координата результату дорівнює Y вектора помноженому на скаляр
            Assert.That(result.Y, Is.EqualTo(a.Y * b));
        }

        // Тест для перевірки обчислення довжини вектора
        [Test]
        public void Length()
        {
            // Створення вектора з координатами (3, 4) - має довжину 5 (за теоремою Піфагора)
            var a = new Vector(3, 4);
            // Обчислення довжини вектора
            var result = a.Length();

            // Перевірка, що довжина дорівнює 5 (3² + 4² = 9 + 16 = 25, √25 = 5)
            Assert.That(result, Is.EqualTo(5));
        }
    }
}

namespace Lab7
{
    [TestFixture]
    // Дозволяє паралельне виконання тестів
    [Parallelizable(ParallelScope.All)]
    class MathOperationsTests
    {
        // Тест для перевірки методу додавання
        [Test]
        public void AddResult()
        {
            double a = 3;
            double b = 7;
            // Очікуваний результат додавання
            double expected = 10;

            // Створення екземпляра класу MathOperations
            var math = new MathOperations();
            double result = math.Add(a, b);

            // Перевірка, що результат співпадає з очікуваним
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тест для перевірки методу множення
        [Test]
        public void MultiplyResult()
        {
            // Вхідні дані для тесту (включаючи від'ємне число)
            double a = -1;
            double b = 3;
            double expected = -3;

            // Створення екземпляра класу MathOperations
            var math = new MathOperations();
            // Виклик методу множення
            double result = math.Multiply(a, b);

            // Перевірка, що результат співпадає з очікуваним
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тест для перевірки виклику події
        [Test]
        public void Invoke()
        {
            // Дані для тестування події
            string name = "Test Operation";
            double a = 1;
            double b = 2;
            double result = 3;

            // Створення екземпляра класу MathOperations
            var math = new MathOperations();
            // Лічильник для перевірки кількості викликів події
            int timesCalled = 0;
            
            // Підписка на подію OnOperationPerformed
            math.OnOperationPerformed += (obj, args) =>
            {
                // Збільшення лічильника при кожному виклику
                timesCalled += 1;

                // Перевірки параметрів події:
                // obj має бути посиланням на math об'єкт
                Assert.That(obj, Is.SameAs(math));
                // Назва операції має співпадати
                Assert.That(args.Name, Is.EqualTo(name));
                // Перший аргумент має співпадати
                Assert.That(args.A, Is.EqualTo(a));
                // Другий аргумент має співпадати
                Assert.That(args.B, Is.EqualTo(b));
                // Результат має співпадати
                Assert.That(args.Result, Is.EqualTo(result));
            };
            
            // Примусовий виклик події для тестування
            math.InvokeOperationPerformed(name, a, b, result);

            // Перевірка, що подія викликалась рівно один раз
            Assert.That(timesCalled, Is.EqualTo(1));
        }

        // Тест для перевірки, що подія викликається при додаванні
        [Test]
        public void AddEvent()
        {
            // Вхідні дані для додавання
            double a = 1;
            double b = 2;
            double result = 3;  // Очікуваний результат

            // Створення екземпляра класу MathOperations
            var math = new MathOperations();
            // Лічильник для перевірки кількості викликів події
            int timesCalled = 0;
            
            // Підписка на подію OnOperationPerformed
            math.OnOperationPerformed += (obj, args) =>
            {
                // Збільшення лічильника при кожному виклику
                timesCalled += 1;

                // Перевірки параметрів події:
                // Перший аргумент має співпадати
                Assert.That(args.A, Is.EqualTo(a));
                // Другий аргумент має співпадати
                Assert.That(args.B, Is.EqualTo(b));
                // Результат має співпадати
                Assert.That(args.Result, Is.EqualTo(result));
            };
            
            // Виклик методу додавання, який має викликати подію
            math.Add(a, b);

            // Перевірка, що подія викликалась рівно один раз
            Assert.That(timesCalled, Is.EqualTo(1));
        }

        // Тест для перевірки, що подія викликається при множенні
        [Test]
        public void MultiplyEvent()
        {
            // Вхідні дані для множення
            double a = 1;
            double b = 2;
            double result = 2;  // Очікуваний результат

            // Створення екземпляра класу MathOperations
            var math = new MathOperations();
            // Лічильник для перевірки кількості викликів події
            int timesCalled = 0;
            
            // Підписка на подію OnOperationPerformed
            math.OnOperationPerformed += (obj, args) =>
            {
                // Збільшення лічильника при кожному виклику
                timesCalled += 1;

                // Перевірки параметрів події:
                // Перший аргумент має співпадати
                Assert.That(args.A, Is.EqualTo(a));
                // Другий аргумент має співпадати
                Assert.That(args.B, Is.EqualTo(b));
                // Результат має співпадати
                Assert.That(args.Result, Is.EqualTo(result));
            };
            
            // Виклик методу множення, який має викликати подію
            math.Multiply(a, b);

            // Перевірка, що подія викликалась рівно один раз
            Assert.That(timesCalled, Is.EqualTo(1));
        }
    }
}