namespace ClassesLab.Tests;
internal static class TestHelpers
{
    public static string Capture(Action action)
    {
        var old = Console.Out;
        using var writer = new StringWriter();
        try { Console.SetOut(writer); action(); return writer.ToString(); }
        finally { Console.SetOut(old); }
    }
}
