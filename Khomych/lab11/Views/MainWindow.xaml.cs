using System.Windows;
using System.Windows.Controls;

namespace BookManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Суто візуальна поведінка: прокручує список до вибраної книги,
        // щоб щойно додану книгу було видно навіть у довгому списку.
        private void BooksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }
    }
}
