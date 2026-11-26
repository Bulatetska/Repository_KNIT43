using Lab5Classes.Models;
using NUnit.Framework;

namespace Lab9Tests;

internal static class ConsoleOutput
{
    public static string Capture(Action action)
    {
        TextWriter original = Console.Out;
        using var writer = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
        try
        {
            Console.SetOut(writer);
            action();
            return writer.ToString();
        }
        finally { Console.SetOut(original); }
    }
}
