using System.Windows;

namespace HelloWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;

            if (!string.IsNullOrWhiteSpace(name))
                GreetingText.Text = $"Привіт, {name}!";
            else
                GreetingText.Text = "Будь ласка, введіть ім'я.";
        }
    }
}
