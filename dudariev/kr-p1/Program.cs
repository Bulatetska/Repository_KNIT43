using System.Text;
using System.Text.RegularExpressions;

// Задано рядок. Написати програму на мові C# яка видаляє між словами пробіли, якщо їх більше 1, залишаючи між словами по 1 пробілу.

//string ProcessString(string input)
//{
//    return Regex.Replace(input, " +", " ");
//}

string ProcessString(string input)
{
    var output = new StringBuilder();
    bool wasSpace = false;
    foreach (var c in input)
    {
        if (c != ' ' || !wasSpace)
        {
            output.Append(c);
        }
        wasSpace = c == ' ';
    }
    return output.ToString();
}

Console.Write("Введіть рядок: ");
string input = Console.ReadLine() ?? "";
var output = ProcessString(input);
Console.WriteLine("'{0}'", output);
