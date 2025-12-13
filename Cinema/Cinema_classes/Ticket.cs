using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_classes
{
    public abstract class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MovieTitle { get; set; }
        public string HallName { get; set; }
        public DateTime SessionDate { get; set; }
        public int Row { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }

        public abstract string PrintTicket();
    }

    public class StandartTicket : Ticket
    {

        public StandartTicket(decimal price)
        {
            Price = price;
        }

        public override string PrintTicket()
        {
            return $"STANDART  {MovieTitle}" +
                $" \n ID: {Id}" +
                $" \n Hall name: {HallName}" +
                $" \n SessionDate: {SessionDate}" +
                $" \n Row: {Row}" +
                $" \n Seat: {SeatNumber}" +
                $" \n Price: {Price}";
        }
    }

    public class VipTicket : Ticket
    {
        public VipTicket(decimal basePrice)
        {
            Price = basePrice * 1.5m;
        }
        public override string PrintTicket()
        {
            return $"VIP {MovieTitle}" +
                $" \n ID: {Id}" +
                $" \n Hall name: {HallName}" +
                $" \n SessionDate: {SessionDate}" +
                $" \n Row: {Row}" +
                $" \n Seat: {SeatNumber}" +
                $" \n Price: {Price}";
        }
    }
}

