using NUnit.Framework;

namespace Lab6
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class Tests
    {
        [Test]
        public void Negate()
        {
            var a = new Vector(3, -4.5);

            var result = -a;

            Assert.That(result.x, Is.EqualTo(-a.x));
            Assert.That(result.y, Is.EqualTo(-a.y));
        }

        [Test]
        public void Add()
        {
            var a = new Vector(2, 4);
            var b = new Vector(1, -1);

            var result = a + b;

            Assert.That(result.x, Is.EqualTo(a.x + b.x));
            Assert.That(result.y, Is.EqualTo(a.y + b.y));
        }

        [Test]
        public void Equals()
        {
            var a = new Vector(2, 4);
            var b = new Vector(1, -1);
            var c = new Vector(2, 4);

            Assert.That(a == b, Is.False);
            Assert.That(a == c, Is.True);
        }

        [Test]
        public void NotEquals()
        {
            var a = new Vector(2, 4);
            var b = new Vector(1, -1);
            var c = new Vector(2, 4);

            Assert.That(a != b, Is.True);
            Assert.That(a != c, Is.False);
        }

        [Test]
        public void Multiply()
        {
            var a = new Vector(2, 4);
            var b = 3;

            var result = a * b;

            Assert.That(result.x, Is.EqualTo(a.x * b));
            Assert.That(result.y, Is.EqualTo(a.y * b));
        }

        [Test]
        public void Length()
        {
            var a = new Vector(3, 4);

            var result = a.Length();

            Assert.That(result, Is.EqualTo(5));
        }
    }
}

namespace Lab7
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class Tests
    {
        [Test]
        public void AddResult()
        {
            double a = 3;
            double b = 7;
            double expected = 10;

            var math = new MathOperations();
            double result = math.Add(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MultiplyResult()
        {
            double a = -1;
            double b = 3;
            double expected = -3;

            var math = new MathOperations();
            double result = math.Multiply(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Invoke()
        {
            string name = "Test Operation";
            double a = 1;
            double b = 2;
            double result = 3;

            var math = new MathOperations();
            int timesCalled = 0;
            math.OnOperationPerformed += (obj, args) =>
            {
                timesCalled += 1;

                Assert.That(obj, Is.SameAs(math));
                Assert.That(args.Name, Is.EqualTo(name));
                Assert.That(args.A, Is.EqualTo(a));
                Assert.That(args.B, Is.EqualTo(b));
                Assert.That(args.Result, Is.EqualTo(result));
            };
            math.InvokeOperationPerformed(name, a, b, result);

            Assert.That(timesCalled, Is.EqualTo(1));
        }

        [Test]
        public void AddEvent()
        {
            double a = 1;
            double b = 2;
            double result = 3;

            var math = new MathOperations();
            int timesCalled = 0;
            math.OnOperationPerformed += (obj, args) =>
            {
                timesCalled += 1;

                Assert.That(args.A, Is.EqualTo(a));
                Assert.That(args.B, Is.EqualTo(b));
                Assert.That(args.Result, Is.EqualTo(result));
            };
            math.Add(a, b);

            Assert.That(timesCalled, Is.EqualTo(1));
        }

        [Test]
        public void MultiplyEvent()
        {
            double a = 1;
            double b = 2;
            double result = 2;

            var math = new MathOperations();
            int timesCalled = 0;
            math.OnOperationPerformed += (obj, args) =>
            {
                timesCalled += 1;

                Assert.That(args.A, Is.EqualTo(a));
                Assert.That(args.B, Is.EqualTo(b));
                Assert.That(args.Result, Is.EqualTo(result));
            };
            math.Multiply(a, b);

            Assert.That(timesCalled, Is.EqualTo(1));
        }
    }
}