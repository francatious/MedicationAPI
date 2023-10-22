using MedicationAPI.Models;

namespace MedicationApi.Business.Interfaces
{
    public interface IMedication
    {
        Task<Response<IEnumerable<Medication>>> GetMedications();
        Task<Response<Medication>> CreateMedication(NewMedication medicationToCreate);
        Task<Response<bool>> DeleteMedication(int medicationId);
    }
}