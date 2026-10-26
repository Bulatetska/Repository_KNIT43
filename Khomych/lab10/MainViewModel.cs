using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreetingApp
{
    /// <summary>
    /// Модель представлення: зберігає ім'я та текст привітання.
    /// INotifyPropertyChanged повідомляє інтерфейс про зміну властивостей,
    /// завдяки чому працює прив'язка даних (Data Binding).
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _userName = string.Empty;
        private string _greeting = string.Empty;

        /// <summary>Ім'я, введене користувачем (прив'язане до TextBox).</summary>
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>Текст привітання (прив'язаний до TextBlock результату).</summary>
        public string Greeting
        {
            get => _greeting;
            set
            {
                if (_greeting != value)
                {
                    _greeting = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
