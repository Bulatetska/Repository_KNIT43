using System.Text;

namespace kr_p3
{
    public class StringProcessor
    {
        public static string ProcessString(string input)
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
    }
}
