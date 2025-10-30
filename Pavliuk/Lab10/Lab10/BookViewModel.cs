using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Lab10
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private Book selectedBook;
        public ObservableCollection<Book> Books { get; set; }
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        public BookViewModel()
        {
            Books = new ObservableCollection<Book> { 
                new Book {Title = "Alice in Wonderland", Author="Luis Carroll", Year = 1865},
                new Book {Title = "Golden Boys", Author="Phil Stamper", Year = 2019},
                new Book {Title = "Pollianna", Author="a", Year = 1850},
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Book book = new Book();
                        Books.Insert(0, book);
                        SelectedBook = book;
                    }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Book book = obj as Book;
                        if (book != null) { 
                            Books.Remove(book);
                        }
                    },
                    (obj)=> Books.Count>0));
            }
        }
    }
}
