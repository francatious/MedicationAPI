using MedicationAPI.Models;

namespace MedicationAPI.Repo.Interfaces
{
    public interface IMedication
    {
        Task<IEnumerable<Medication>> GetMedications();
        Task<Medication> GetMedicationById(int medicationId);
        Task<Medication> CreateMedication(NewMedication medication);
        Task<bool> DeleteMedication(int medicationId);
    }
}