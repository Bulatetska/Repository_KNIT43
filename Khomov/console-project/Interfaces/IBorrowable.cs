using ConsoleProject.Models;

namespace ConsoleProject.Interfaces;

public interface IBorrowable
{
    bool IsBorrowed { get; }
    Member? BorrowedBy { get; }
    DateTime? BorrowedAt { get; }

    bool Borrow(Member member);
    bool Return();
}
