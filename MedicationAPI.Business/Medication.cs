using MedicationApi.Business.Interfaces;
using MedicationAPI.Models;

namespace MedicationAPI.Business
{
    public class Medication : IMedication
    {
        private readonly Repo.Interfaces.IMedication _medicationRepo;

        public Medication(Repo.Interfaces.IMedication medicationRepo)
        {
            _medicationRepo = medicationRepo;
        }

        

        public async Task<Response<IEnumerable<Models.Medication>>> GetMedications()
        {
            try
            {
                var medications = await this._medicationRepo.GetMedications();

                return new Response<IEnumerable<Models.Medication>>(medications);
            }
            catch(Exception ex)
            {
                return new Response<IEnumerable<Models.Medication>>(500, ex.Message);
            }
        }

        public async Task<Response<Models.Medication>> CreateMedication(NewMedication medicationToCreate)
        {
            try
            {
                if (medicationToCreate.Quantity <= 0)
                {
                    return new Response<Models.Medication>(400, "New medications must have a quantity higher than zero.");
                }

                var newMedication = await this._medicationRepo.CreateMedication(medicationToCreate);

                return new Response<Models.Medication>(newMedication);
                
            }
            catch(Exception ex)
            {
                return new Response<Models.Medication>(500, ex.Message);
            }
        }

        public async Task<Response<bool>> DeleteMedication(int medicationId)
        {
            try
            {
                var deletedMedication = await this._medicationRepo.DeleteMedication(medicationId);
                if (!deletedMedication)
                {
                    return new Response<bool>(400, "The medication intended to be deleted could not be found.");
                }

                return new Response<bool>(deletedMedication);
            }
            catch(Exception ex)
            {
                return new Response<bool>(500, ex.Message);
            }
        }
    }
}