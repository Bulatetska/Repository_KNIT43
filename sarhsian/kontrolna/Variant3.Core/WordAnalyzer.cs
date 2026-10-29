using System.Text;

namespace Variant3.Core;

public record WordAnalysisResult(int Count, IReadOnlyList<int> Positions, bool HasLatinI);

public static class WordAnalyzer
{
    public static WordAnalysisResult Analyze(string word)
    {
        if (string.IsNullOrWhiteSpace(word) || word.Any(char.IsWhiteSpace))
            throw new ArgumentException("Введіть одне слово без пробілів.");

        word = word.Normalize(NormalizationForm.FormC);

        List<int> positions = new();
        bool hasLatinI = false;

        for (int i = 0; i < word.Length; i++)
        {
            char letter = word[i];

            if (letter == '\u0456' || letter == '\u0406')
                positions.Add(i + 1);

            if (letter == 'i' || letter == 'I')
                hasLatinI = true;
        }

        return new WordAnalysisResult(positions.Count, positions, hasLatinI);
    }
}
