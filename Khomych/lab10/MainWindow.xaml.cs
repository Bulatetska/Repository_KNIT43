using System.Windows;

namespace GreetingApp
{
    public partial class MainWindow : Window
    {
        // Модель, з якою працює прив'язка даних
        private readonly MainViewModel _viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();

            // Встановлюємо контекст даних — усі {Binding} у XAML
            // звертаються до властивостей цього об'єкта
            DataContext = _viewModel;
        }

        /// <summary>
        /// Обробник натискання кнопки "Підтвердити".
        /// Текст із TextBox уже потрапив у UserName через прив'язку,
        /// тож ми формуємо привітання, і воно автоматично з'являється в TextBlock.
        /// </summary>
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string name = _viewModel.UserName.Trim();

            if (string.IsNullOrEmpty(name))
            {
                _viewModel.Greeting = "Будь ласка, введіть ім'я.";
                NameTextBox.Focus();
                return;
            }

            _viewModel.Greeting = $"Привіт, {name}!";
        }
    }
}
