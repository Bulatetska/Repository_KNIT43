using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookManager.Infrastructure
{
    /// <summary>
    /// Базовий клас з реалізацією INotifyPropertyChanged.
    /// Спільний для моделі та ViewModel, щоб не дублювати код сповіщень.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Записує нове значення у поле і сповіщає View, якщо значення змінилося.
        /// </summary>
        /// <returns>true, якщо значення було змінено.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
