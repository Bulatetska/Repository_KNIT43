using Hospital.Core.Models;

namespace Hospital.Core.Interfaces
{
    public interface IMedicalStaff
    {
        void PerformExamination(Patient patient);
        string GetSchedule();
    }
}