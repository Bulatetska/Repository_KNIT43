using ConsoleProject.Interfaces;

namespace ConsoleProject.Models;

public class Dvd : LibraryItem, IBorrowable
{
    public int DurationMinutes { get; }

    public Dvd(string title, int durationMinutes, int year) : base(title, year)
    {
        DurationMinutes = durationMinutes;
    }

    public bool IsBorrowed { get; private set; }
    public Member? BorrowedBy { get; private set; }
    public DateTime? BorrowedAt { get; private set; }

    public bool Borrow(Member member)
    {
        if (IsBorrowed) return false;
        BorrowedBy = member;
        BorrowedAt = DateTime.Now;
        IsBorrowed = true;
        return true;
    }

    public bool Return()
    {
        if (!IsBorrowed) return false;
        BorrowedBy = null;
        BorrowedAt = null;
        IsBorrowed = false;
        return true;
    }

    public override string ToString() => $"{base.ToString()} [{DurationMinutes} min]";
}
