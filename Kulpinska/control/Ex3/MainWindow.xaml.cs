using System.Windows;

namespace LastIPosition
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            int lastIndex = input.LastIndexOf('і');

            if (lastIndex != -1)
                ResultTextBlock.Text = $"Остання буква 'і' знаходиться на позиції: {lastIndex}";
            else
                ResultTextBlock.Text = "Буква 'і' не знайдена у рядку.";
        }
    }
}
