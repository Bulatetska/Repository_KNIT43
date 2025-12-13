using System;
using System.Collections.Generic;

public abstract class Ticket
{
    public string MovieTitle { get; protected set; }
    public string SeatInfo { get; protected set; }
    public decimal Price { get; protected set; }

    protected Ticket(string title, string info, decimal price)
    {
        MovieTitle = title;
        SeatInfo = info;
        Price = price;
    }

    public abstract string PrintTicket();
}

public abstract class Ticket
{
    public string MovieTitle { get; protected set; }
    public string SeatInfo { get; protected set; }
    public decimal Price { get; protected set; }

    protected Ticket(string title, string info, decimal price)
    {
        MovieTitle = title;
        SeatInfo = info;
        Price = price;
    }

    public abstract string PrintTicket();
}

public class User
{
    public string Name { get; }
    public string Email { get; }
    public List<Ticket> PurchaseHistory { get; } = new List<Ticket>();

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void BuyTicket(Ticket ticket)
    {
        PurchaseHistory.Add(ticket);
        Console.WriteLine($"\n[Повідомлення для {Name}]: Квиток успішно додано до історії.");
    }

    public void DisplayHistory()
    {
        Console.WriteLine($"\n--- Історія покупок {Name} ---");
        if (PurchaseHistory.Count == 0)
        {
            Console.WriteLine("Історія порожня.");
            return;
        }
        foreach (var ticket in PurchaseHistory)
        {
            Console.WriteLine(ticket.PrintTicket());
        }
        Console.WriteLine("--------------------------------");
    }
}