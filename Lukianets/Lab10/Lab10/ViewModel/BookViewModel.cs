using Lab10.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab10.ViewModel
{
    // ViewModel для керування списком книг.
    // Вона є "посередником" між View (вікном) і Model (Book),
    // зберігає стан і логіку додавання, редагування, видалення.
    public class BookViewModel : INotifyPropertyChanged
    {
        // 🔹 Приватні змінні для властивостей
        private Book? _selectedBook = null; // Поточна вибрана книга
        private string _inputTitle = "";    // Назва, введена у поле
        private string _inputAuthor = "";   // Автор, введений у поле
        private int _inputYear = DateTime.Now.Year; // Рік, введений у поле (за замовчуванням поточний рік)

        // 🔹 Колекція книг, яка автоматично оновлює View при зміні
        // ObservableCollection — це колекція, яка надсилає події при додаванні або видаленні елементів.
        public ObservableCollection<Book> Books { get; } = new ObservableCollection<Book>();

        // 🔹 Вибрана книга у списку (ListBox)
        public Book? SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook)); // 🔔 Повідомляємо, що вибір змінився

                // Якщо користувач вибрав книгу — копіюємо її дані у поля вводу
                if (value != null)
                {
                    InputTitle = value.Title;
                    InputAuthor = value.Author;
                    InputYear = value.Year;
                }
                else
                {
                    // Якщо вибір скасовано — очищаємо поля
                    ClearInputs();
                }
            }
        }

        // 🔹 Поля введення для назви книги
        public string InputTitle
        {
            get => _inputTitle;
            set
            {
                _inputTitle = value;
                OnPropertyChanged(nameof(InputTitle)); // 🔔 Оновлюємо View при зміні
            }
        }

        // 🔹 Поля введення для автора
        public string InputAuthor
        {
            get => _inputAuthor;
            set
            {
                _inputAuthor = value;
                OnPropertyChanged(nameof(InputAuthor));
            }
        }

        // 🔹 Поля введення для року видання
        public int InputYear
        {
            get => _inputYear;
            set
            {
                _inputYear = value;
                OnPropertyChanged(nameof(InputYear));
            }
        }

        // ==============================
        // 🔹 Команди (Buttons у View)
        // ==============================

        // Команда для додавання нової книги
        public ICommand AddBookCommand { get; }

        // Команда для видалення вибраної книги
        public ICommand DeleteBookCommand { get; }

        // Команда для оновлення даних вибраної книги
        public ICommand UpdateBookCommand { get; }

        // ==============================
        // 🔹 Конструктор
        // ==============================
        public BookViewModel()
        {
            // Ініціалізуємо команди, передаючи методи, які вони виконують
            AddBookCommand = new CommandHandler(AddBook);
            DeleteBookCommand = new CommandHandler(DeleteBook);
            UpdateBookCommand = new CommandHandler(UpdateBook);

            // Додаємо кілька початкових книг у список для демонстрації
            Books.Add(new Book { Title = "1984", Author = "Дж. Орвелл", Year = 1949 });
            Books.Add(new Book { Title = "Володар перснів", Author = "Дж. Р. Р. Толкін", Year = 1954 });
        }

        // ==============================
        // 🔹 Методи команд
        // ==============================

        // Додає нову книгу у список.
        private void AddBook()
        {
            // Перевіряємо, чи введено назву і автора
            if (!string.IsNullOrWhiteSpace(InputTitle) && !string.IsNullOrWhiteSpace(InputAuthor))
            {
                // Створюємо новий об’єкт Book
                var newBook = new Book
                {
                    Title = InputTitle,
                    Author = InputAuthor,
                    Year = InputYear
                };

                // Додаємо книгу до колекції (автоматично оновиться у View)
                Books.Add(newBook);

                // Очищаємо поля після додавання
                ClearInputs();
            }
        }

        // Видаляє вибрану книгу зі списку.
        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook); // Видаляємо книгу
                SelectedBook = null;        // Скасовуємо вибір
                ClearInputs();              // Очищаємо поля
            }
        }

        // Оновлює дані вибраної книги (редагування).
        private void UpdateBook()
        {
            if (SelectedBook != null)
            {
                // Змінюємо властивості книги
                SelectedBook.Title = InputTitle;
                SelectedBook.Author = InputAuthor;
                SelectedBook.Year = InputYear;
            }
        }

        // Очищає текстові поля після додавання або видалення.
        private void ClearInputs()
        {
            InputTitle = "";
            InputAuthor = "";
            InputYear = DateTime.Now.Year;
        }

        // ==============================
        // 🔹 Реалізація INotifyPropertyChanged
        // ==============================
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            // 🔔 Викликає подію, щоб повідомити WPF про зміну властивості
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // =====================================
    // 🔹 Реалізація простої команди ICommand
    // =====================================

    public class CommandHandler : ICommand
    {
        private readonly Action _action; // Метод, який потрібно виконати

        // Конструктор приймає метод, який буде викликатись
        public CommandHandler(Action action) => _action = action;

        // Подія, яку можна викликати для оновлення стану кнопок (не використовується тут)
        public event EventHandler? CanExecuteChanged;

        // Метод, який визначає, чи доступна команда (у нас завжди доступна)
        public bool CanExecute(object? parameter) => true;

        // Виконує передану дію при натисканні кнопки
        public void Execute(object? parameter) => _action();
    }
}
