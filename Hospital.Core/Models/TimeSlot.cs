using System;

namespace Hospital.Core.Models
{
    public class TimeSlot
    {
        public DateTime Time { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int DurationMinutes { get; set; } = 30;
    }
}