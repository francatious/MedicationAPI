using MedicationAPI.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly MedicationAPI.Repo.Interfaces.IMedication _medicationRepo;
        
        public MedicationController(IMedication medicationRepo)
        {
            _medicationRepo = medicationRepo;
        }

        [HttpGet("medications")]
        public async Task<IActionResult> GetMedications()
        {
            var result = await _medicationRepo.GetMedications();
            return new ObjectResult(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMedication(Models.NewMedication medicationToCreate)
        {
            var result = await _medicationRepo.CreateMedication(medicationToCreate);
            return new ObjectResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedication(int medicationId)
        {
            var result = await _medicationRepo.DeleteMedication(medicationId);
            return new ObjectResult(result);
        }


    }
}