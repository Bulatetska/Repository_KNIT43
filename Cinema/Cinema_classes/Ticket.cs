using System;

namespace Cinema_classes
{
    public abstract class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string MovieTitle { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
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
            return $"STANDART {MovieTitle} | ID: {Id} | Ряд: {Row}, Місце: {SeatNumber} | Ціна: {Price}";
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
            return $"VIP {MovieTitle} | ID: {Id} | Ряд: {Row}, Місце: {SeatNumber} | Ціна: {Price}";
        }
    }
}

