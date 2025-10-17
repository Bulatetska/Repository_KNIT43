using System.Windows;
using System.Windows.Data;

namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BookViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel = new BookViewModel();
            viewModel.OnBookAdded += (_, _) => title.Focus();
        }

        private void Window_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            grid.Focus();
        }
    }
}