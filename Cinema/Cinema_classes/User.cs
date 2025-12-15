using System.Collections.Generic;
using System;
using System.Linq;

namespace Cinema_classes
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public List<Ticket> PurchaseHistory { get; } = new List<Ticket>();

        public User(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            PhoneNumber = phone;
        }

        public void BuyTicket(Ticket ticket)
        {
            PurchaseHistory.Add(ticket);
        }
    }
}