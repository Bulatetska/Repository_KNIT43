using System.Windows;

namespace lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel = new MainWindowViewModel();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            string name = viewModel.Name.Trim();
            viewModel.Message = name != "" ? $"Привіт, {name}!" : "";
        }
    }
}