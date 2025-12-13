using System;
using System.Linq;

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
            cinemaService.ProcessBooking(user, selectedSession, row: 1, seat: 5);
            cinemaService.ProcessBooking(user, selectedSession, row: 5, seat: 1);
            cinemaService.ProcessBooking(user, selectedSession, row: 1, seat: 5);
            user.DisplayHistory();
        }
    }
}