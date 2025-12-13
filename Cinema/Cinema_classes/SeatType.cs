namespace Cinema_classes
{
    public enum SeatType
    {
        Standard,
        VIP
    }
    public interface IBookable
    {
        bool BookSeat(int row, int number);
        void CancelBooking(int row, int number);
        bool IsSeatAvailable(int row, int number);
    }
}