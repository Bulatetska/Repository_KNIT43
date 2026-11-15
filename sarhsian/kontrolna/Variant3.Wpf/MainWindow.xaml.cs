using System.Windows;
using Variant3.Core;

namespace Variant3.Wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ProcessButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = WordAnalyzer.Analyze(WordTextBox.Text);
            ResultTextBlock.Text = result.Count > 0
                ? $"Кількість букв «і»: {result.Count}\nПозиції: {string.Join(", ", result.Positions)}"
                : result.HasLatinI
                    ? "Кількість букв «і»: 0. У слові є латинська i/I. Перемкніть розкладку на українську."
                    : "Кількість букв «і»: 0. Українську букву «і» не знайдено.";
        }
        catch (ArgumentException ex)
        {
            ResultTextBlock.Text = ex.Message;
        }
    }
}
