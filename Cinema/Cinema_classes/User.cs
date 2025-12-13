using System.Collections.Generic;

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
    }
}