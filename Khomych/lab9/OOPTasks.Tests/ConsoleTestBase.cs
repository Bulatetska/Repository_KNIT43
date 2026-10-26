using System;
using System.Globalization;
using System.IO;

namespace OOPTasks.Tests
{
    /// <summary>
    /// Базовий клас для тестів, які перевіряють вивід у консоль.
    /// Перед кожним тестом перехоплює Console.Out у StringWriter,
    /// після тесту — повертає стандартний вивід.
    /// Культура фіксується як InvariantCulture, щоб дробові числа
    /// завжди виводились з крапкою (1500.5), незалежно від налаштувань ПК.
    /// </summary>
    public abstract class ConsoleTestBase
    {
        private TextWriter originalOut = null!;
        private CultureInfo originalCulture = null!;
        protected StringWriter Output = null!;

        protected static string NL => Environment.NewLine;

        [SetUp]
        public void RedirectConsole()
        {
            originalOut = Console.Out;
            originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Output = new StringWriter();
            Console.SetOut(Output);
        }

        [TearDown]
        public void RestoreConsole()
        {
            Console.SetOut(originalOut);
            CultureInfo.CurrentCulture = originalCulture;
            Output.Dispose();
        }

        /// <summary>Повертає все, що було виведено в консоль під час тесту.</summary>
        protected string ConsoleText => Output.ToString();
    }
}
