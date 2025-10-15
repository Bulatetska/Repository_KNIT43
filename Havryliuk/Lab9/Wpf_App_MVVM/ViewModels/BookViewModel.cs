using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace SimpleWPFApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _userName;
        private string _greetingMessage;
        private Brush _messageColor;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(IsFormValid));
                
                // Оновлюємо повідомлення при зміні імені
                if (string.IsNullOrWhiteSpace(value))
                {
                    GreetingMessage = "Чекаю на ваше ім'я...";
                    MessageColor = new SolidColorBrush(Colors.Gray);
                }
            }
        }

        public string GreetingMessage
        {
            get => _greetingMessage;
            set
            {
                _greetingMessage = value;
                OnPropertyChanged(nameof(GreetingMessage));
            }
        }

        public Brush MessageColor
        {
            get => _messageColor;
            set
            {
                _messageColor = value;
                OnPropertyChanged(nameof(MessageColor));
            }
        }

        public bool IsFormValid => !string.IsNullOrWhiteSpace(UserName);

        public ICommand ConfirmCommand { get; }

        public MainViewModel()
        {
            ConfirmCommand = new RelayCommand(ExecuteConfirm, CanExecuteConfirm);
            GreetingMessage = "Чекаю на ваше ім'я...";
            MessageColor = new SolidColorBrush(Colors.Gray);
        }

        private void ExecuteConfirm(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                GreetingMessage = $"Привіт, {UserName}! \nРаді бачити вас у нашому додатку!";
                MessageColor = new SolidColorBrush(Color.FromRgb(46, 125, 50)); // Зелений
            }
            else
            {
                GreetingMessage = "Будь ласка, введіть ваше ім'я перед підтвердженням.";
                MessageColor = new SolidColorBrush(Color.FromRgb(211, 47, 47)); // Червоний
            }
        }

        private bool CanExecuteConfirm(object parameter) => IsFormValid;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}