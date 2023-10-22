using AutoMapper;

namespace MedicationAPI.Repo.Mappers
{
    public class Medication : Profile
    {
        public Medication()
        {
            CreateMap<DataModels.MedicationDataModels.Medication, Models.Medication>();
        }
    }
}