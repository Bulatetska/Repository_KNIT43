using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Task1(string input)
        {
            int lastIndex = input.ToLower().LastIndexOf('і');

            if (lastIndex >= 0)
                return $"Остання буква 'і' знаходиться на позиції: {lastIndex + 1}";
            else
                return "Буква 'і' не знайдена у рядку.";
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            string result = Task1(input);
            ResultTextBlock.Text = result;
        }

    }

}