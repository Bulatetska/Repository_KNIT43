using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Model
{
    // Клас Book (Книга) — модель, яка описує основні властивості книги.
    // Реалізує інтерфейс INotifyPropertyChanged, щоб підтримувати прив’язку даних (Data Binding) у WPF.
    public class Book : INotifyPropertyChanged
    {
        // 🔹 Приватні поля — зберігають дані про книгу
        private string _title;   // Назва книги
        private string _author;  // Автор книги
        private int _year;       // Рік видання

        // 🔹 Властивість Title (Назва книги)
        // Використовується у прив’язці даних. Коли значення змінюється — викликається подія OnPropertyChanged,
        // щоб інтерфейс (View) оновив текст автоматично.
        public string Title
        {
            get => _title;  // Повертає поточне значення
            set
            {
                _title = value;  // Змінює значення
                OnPropertyChanged(nameof(Title)); // 🔔 Сповіщає, що властивість змінилась
            }
        }

        // 🔹 Властивість Author (Автор книги)
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author)); // 🔔 Оновлює прив’язку у View
            }
        }

        // 🔹 Властивість Year (Рік видання)
        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year)); // 🔔 Повідомляє ViewModel і View про зміну
            }
        }

        // 🔹 Подія PropertyChanged — частина інтерфейсу INotifyPropertyChanged.
        // Вона сповіщає систему прив’язки (Binding Engine), що властивість змінилась.
        public event PropertyChangedEventHandler? PropertyChanged;

        // 🔹 Метод, який викликає подію PropertyChanged
        // Його викликають у set-методах усіх властивостей.
        protected void OnPropertyChanged(string propertyName)
        {
            // Якщо є підписники (наприклад, View), викликається подія з іменем властивості
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
