using System.Collections.Generic;
using Hospital.Core.Models;

namespace Hospital.Core.Interfaces
{
    public interface IPatientService
    {
        Patient RegisterPatient(string firstName, string lastName, string phone, string email);
        Patient FindPatientById(int id);
        List<Patient> SearchPatients(string searchTerm);
    }
}
