using System;

namespace Hospital.Core.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        
        public string GetFullName() => $"{FirstName} {LastName}";
        public int GetAge() => DateTime.Now.Year - DateOfBirth.Year;
    }
}
