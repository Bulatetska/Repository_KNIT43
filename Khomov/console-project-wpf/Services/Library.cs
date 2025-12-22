using ConsoleProject.Interfaces;
using ConsoleProject.Models;

namespace ConsoleProject.Services;

public class Library
{
    private readonly List<LibraryItem> _items = [];
    private readonly List<Member> _members = [];

    public IEnumerable<LibraryItem> Items => _items;
    public IEnumerable<Member> Members => _members;

    public void AddItem(LibraryItem item) => _items.Add(item);
    public void RegisterMember(Member member) => _members.Add(member);

    public bool BorrowItem(Guid itemId, Guid memberId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is not IBorrowable borrowable) return false;
        var member = _members.FirstOrDefault(m => m.Id == memberId);
        if (member is null) return false;
        return borrowable.Borrow(member);
    }

    public bool ReturnItem(Guid itemId)
    {
        var item = _items.FirstOrDefault(i => i.Id == itemId);
        if (item is not IBorrowable borrowable) return false;
        return borrowable.Return();
    }

    public IEnumerable<LibraryItem> Search(string query) => _items.Where(i => i.ToString().Contains(query, StringComparison.OrdinalIgnoreCase));
}
