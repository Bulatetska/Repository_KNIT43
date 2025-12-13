using System.Collections.Generic;
using System;

namespace Cinema_classes
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Ticket> PurchaseHistory { get; } = new List<Ticket>();

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void BuyTicket(Ticket ticket)
        {
            PurchaseHistory.Add(ticket);
        }

        public void DisplayHistory()
        {
            Console.WriteLine($"\n--- ²ÑÒÎĞ²ß ÏÎÊÓÏÎÊ ÊÎĞÈÑÒÓÂÀ×À {Name} ---");
            if (PurchaseHistory.Any())
            {
                foreach (var ticket in PurchaseHistory)
                {
                    Console.WriteLine(ticket.PrintTicket());
                    Console.WriteLine("---");
                }
            }
            else
            {
                Console.WriteLine("²ñòîğ³ÿ ïîğîæíÿ.");
            }
        }
    } 
} 