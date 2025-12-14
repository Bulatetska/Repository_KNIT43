using System;
using System.Linq;
using Cinema_classes;

namespace Cinema_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cinemaService = new CinemaService();
            cinemaService.Initialize();
            var user = cinemaService.CurrentUser;
            var sessions = cinemaService.GetAvailableSessions();
            if (!sessions.Any()) return;
            var selectedSession = sessions[0];
            Console.WriteLine($"\n--- Поточний користувач: {user.Name} ---");
            Console.WriteLine($"Обраний сеанс: {selectedSession}");
            cinemaService.ProcessBooking(user, selectedSession, row: 1, seatNum: 5);
            cinemaService.ProcessBooking(user, selectedSession, row: 5, seatNum: 1);
            cinemaService.ProcessBooking(user, selectedSession, row: 1, seatNum: 5);
            //user.DisplayHistory();
        }
    }
}