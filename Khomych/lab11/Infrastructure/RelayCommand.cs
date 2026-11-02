using System;
using System.Windows.Input;

namespace BookManager.Infrastructure
{
    /// <summary>
    /// Універсальна реалізація патерну "Команда" (ICommand):
    /// дія передається делегатом, а умова доступності кнопки - другим делегатом.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object? parameter) => _execute();

        /// <summary>
        /// Просить кнопки перевірити, чи доступна команда зараз.
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
