using System.Collections.ObjectModel;
using System.Diagnostics;

namespace indz
{
    public interface IBorrower<TSelf, TBorrowable>
        where TSelf : class, IBorrower<TSelf, TBorrowable>
        where TBorrowable : class, IBorrowable<TBorrowable, TSelf>
    {
        ObservableCollection<TBorrowable> Borrowed { get; }

        void Borrow(TBorrowable borrowable)
        {
            if (borrowable.Borrower != null)
            {
                throw new InvalidOperationException("borrowable already borrowed");
            }
            Debug.Assert(!Borrowed.Contains(borrowable));

            borrowable.Borrower = (TSelf)this;
            Borrowed.Add(borrowable);
        }

        void Return(TBorrowable borrowable)
        {
            if (!ReferenceEquals(borrowable.Borrower, this))
            {
                throw new InvalidOperationException("borrowable not borrowed by this");
            }
            Debug.Assert(Borrowed.Contains(borrowable));

            borrowable.Borrower = null;
            Borrowed.Remove(borrowable);
        }
    }
}
