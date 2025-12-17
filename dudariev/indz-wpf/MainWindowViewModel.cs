using indz;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

namespace indz_wpf
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Library _Library = new Library();

        private User? _SelectedUser;
        private Book? _SelectedBook;
        public List<User> Users { get => _Library.Users; }
        public List<Book> Books { get => _Library.Books; }
        private string _UsersFilter = "";
        public string UsersFilter
        {
            get => _UsersFilter;
            set
            {
                _UsersFilter = value;
                OnPropertyChanged();
                _UsersView.Refresh();
            }
        }
        private string _BooksFilter = "";
        public string BooksFilter
        {
            get => _BooksFilter;
            set
            {
                _BooksFilter = value;
                OnPropertyChanged();
                _BooksView.Refresh();
                _BorrowableBooksView.Refresh();
                _ReturnableBooksView.Refresh();
            }
        }
        private ICollectionView _UsersView;
        private ICollectionView _BooksView;
        private ICollectionView _BorrowableBooksView;
        private ICollectionView _ReturnableBooksView;
        public ICollectionView UsersView { get => _UsersView; }
        public ICollectionView BooksView { get => _BooksView; }
        public ICollectionView BorrowableBooksView { get => _BorrowableBooksView; }
        public ICollectionView ReturnableBooksView { get => _ReturnableBooksView; }

        public MainWindowViewModel()
        {
            _UsersView = new ListCollectionView(Users);
            _BooksView = new ListCollectionView(Books);
            _BorrowableBooksView = new ListCollectionView(Books);
            _ReturnableBooksView = new ListCollectionView(Books);

            _UsersView.Filter = (object o) => ((User)o).Name.Contains(UsersFilter, StringComparison.CurrentCultureIgnoreCase);
            _BooksView.Filter = (object o) => ((Book)o).Title.Contains(BooksFilter, StringComparison.CurrentCultureIgnoreCase);
            _BorrowableBooksView.Filter = (object o) => _BooksView.Filter(o) && ((Book)o).Borrower == null;
            _ReturnableBooksView.Filter = (object o) => _BooksView.Filter(o) && ((Book)o).Borrower == _SelectedUser && _SelectedUser != null;
        }

        public bool CanBorrow() => _SelectedUser != null && _SelectedBook != null && _SelectedBook.Borrower == null;
        public bool CanReturn() => _SelectedUser != null && _SelectedBook != null && _SelectedBook.Borrower == _SelectedUser;

        private ICommand? borrowBookCommand;
        public ICommand BorrowBookCommand
        {
            get => borrowBookCommand ??= new RelayCommand(
                _ =>
                {
                    if (CanBorrow())
                    {
                        _SelectedUser!.AsIBorrower.Borrow(_SelectedBook!);
                        _BorrowableBooksView.Refresh();
                        _ReturnableBooksView.Refresh();
                    }
                },
               _ => CanBorrow()
            );
        }

        private ICommand? returnBookCommand;
        public ICommand ReturnBookCommand
        {
            get => returnBookCommand ??= new RelayCommand(
                _ =>
                {
                    if (CanReturn())
                    {
                        _SelectedUser!.AsIBorrower.Return(_SelectedBook!);
                        _BorrowableBooksView.Refresh();
                        _ReturnableBooksView.Refresh();
                    }
                },
                _ => CanReturn()
            );
        }

        public User? SelectedUser
        {
            get => _SelectedUser;
            set
            {
                _SelectedUser = value;
                OnPropertyChanged();
                _ReturnableBooksView.Refresh();
            }
        }

        public Book? SelectedBook
        {
            get => _SelectedBook;
            set
            {
                _SelectedBook = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
