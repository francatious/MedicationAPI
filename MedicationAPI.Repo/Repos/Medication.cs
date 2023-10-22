using AutoMapper;
using MedicationAPI.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicationAPI.Repo.Repos
{
    public class Medication : IMedication
    {
        private readonly DataModels.MedicationDataModels.MedicationAPIDbContext _dbContext;
        private readonly IMapper _mapper;

        public Medication(DataModels.MedicationDataModels.MedicationAPIDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Models.Medication> GetMedicationById(int medicationId)
        {
            var dbMedication = await _dbContext.Medications.FirstOrDefaultAsync(med => med.Id == medicationId);

            return _mapper.Map<Models.Medication>(dbMedication);
        }

        public async Task<IEnumerable<Models.Medication>> GetMedications()
        {
            var dbMedications = await _dbContext.Medications.ToListAsync();

            return _mapper.Map<IEnumerable<Models.Medication>>(dbMedications);
        }

        public async Task<Models.Medication> CreateMedication(Models.NewMedication Medication)
        {
            var newMedication = new DataModels.MedicationDataModels.Medication()
            {
                Name = Medication.Name,
                Quantity = Medication.Quantity,
                CreationDate = DateTime.Now
            };

            await _dbContext.Medications.AddAsync(newMedication);
            await _dbContext.SaveChangesAsync();

            return await GetMedicationById(newMedication.Id);
        }

        public async Task<bool> DeleteMedication(int medicationId)
        {
            var medicationToDelete = await _dbContext.Medications.FirstOrDefaultAsync(med => med.Id == medicationId);

            if (medicationToDelete == null)
            {
                return false;
            }

            _dbContext.Remove(medicationToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}