using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PshavaNET_lab11.Commands;
using PshavaNET_lab11.Models;

namespace PshavaNET_lab11.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private Book? _selectedBook;

        public ObservableCollection<Book> Books { get; }

        public RelayCommand AddBookCommand { get; }

        public RelayCommand RemoveBookCommand { get; }

        public Book? SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (ReferenceEquals(_selectedBook, value))
                    return;

                _selectedBook = value;

                OnPropertyChanged();
                RemoveBookCommand.RaiseCanExecuteChanged();
            }
        }

        public BookViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book
                {
                    Title = "Кобзар",
                    Author = "Тарас Шевченко",
                    Year = 1840
                },
                new Book
                {
                    Title = "Місто",
                    Author = "Валер'ян Підмогильний",
                    Year = 1928
                },
                new Book
                {
                    Title = "Тіні забутих предків",
                    Author = "Михайло Коцюбинський",
                    Year = 1911
                }
            };

            AddBookCommand = new RelayCommand(parameter =>
            {
                Book newBook = new Book
                {
                    Title = "Нова книга",
                    Author = "Автор",
                    Year = DateTime.Now.Year
                };

                Books.Add(newBook);

                SelectedBook = newBook;
            });

            RemoveBookCommand = new RelayCommand(
                parameter =>
                {
                    if (parameter is Book book)
                    {
                        int index = Books.IndexOf(book);

                        if (index < 0)
                            return;

                        Books.Remove(book);

                        if (Books.Count == 0)
                        {
                            SelectedBook = null;
                        }
                        else
                        {
                            SelectedBook = Books[
                                Math.Min(index, Books.Count - 1)];
                        }
                    }
                },
                parameter => parameter is Book book
                             && Books.Contains(book)
            );

            SelectedBook = Books.FirstOrDefault();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}