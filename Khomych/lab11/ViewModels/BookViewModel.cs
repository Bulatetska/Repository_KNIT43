using System;
using System.Collections.ObjectModel;
using BookManager.Infrastructure;
using BookManager.Models;

namespace BookManager.ViewModels
{
    /// <summary>
    /// ViewModel головного вікна: зберігає колекцію книг,
    /// вибрану книгу та команди додавання і видалення.
    /// </summary>
    public class BookViewModel : ObservableObject
    {
        private Book? _selectedBook;

        public BookViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book { Title = "Кобзар", Author = "Тарас Шевченко", Year = 1840 },
                new Book { Title = "Чорна рада", Author = "Пантелеймон Куліш", Year = 1857 },
                new Book { Title = "Місто", Author = "Валер'ян Підмогильний", Year = 1928 }
            };

            AddBookCommand = new RelayCommand(AddBook);
            DeleteBookCommand = new RelayCommand(DeleteBook, () => SelectedBook != null);
        }

        public ObservableCollection<Book> Books { get; }

        public RelayCommand AddBookCommand { get; }

        public RelayCommand DeleteBookCommand { get; }

        public Book? SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (SetProperty(ref _selectedBook, value))
                {
                    // Кнопка "Видалити книгу" активна лише тоді, коли книгу вибрано.
                    DeleteBookCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private void AddBook()
        {
            var book = new Book
            {
                Title = "Нова книга",
                Author = "Невідомий автор",
                Year = DateTime.Now.Year
            };

            Books.Add(book);

            // Одразу вибираємо нову книгу, щоб її можна було редагувати.
            SelectedBook = book;
        }

        private void DeleteBook()
        {
            if (SelectedBook == null)
            {
                return;
            }

            int index = Books.IndexOf(SelectedBook);
            Books.Remove(SelectedBook);

            // Вибираємо сусідню книгу, щоб можна було видаляти кілька книг поспіль.
            SelectedBook = Books.Count > 0
                ? Books[Math.Min(index, Books.Count - 1)]
                : null;
        }
    }
}
