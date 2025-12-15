using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Core.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public DateTime Date { get; set; }
        public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
        
        public bool IsAvailable(DateTime time)
        {
            return TimeSlots.Any(slot => slot.Time == time && slot.IsAvailable);
        }
            
        public List<TimeSlot> GetAvailableSlots()
        {
            return TimeSlots.Where(slot => slot.IsAvailable).ToList();
        }
    }
}