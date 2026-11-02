using BookManager.Infrastructure;

namespace BookManager.Models
{
    /// <summary>
    /// Модель книги. Сповіщає про зміну властивостей, тому правки
    /// у полях введення одразу відображаються у списку.
    /// </summary>
    public class Book : ObservableObject
    {
        private string _title = string.Empty;
        private string _author = string.Empty;
        private int _year;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public int Year
        {
            get => _year;
            set => SetProperty(ref _year, value);
        }
    }
}
