using MedicationApi.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly MedicationApi.Business.Interfaces.IMedication _medicationBL;
        
        public MedicationController(IMedication medicationBL)
        {
            _medicationBL = medicationBL;
        }

        [HttpGet("medications")]
        public async Task<IActionResult> GetMedications()
        {
            var result = await _medicationBL.GetMedications();
            return new ObjectResult(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateMedication(Models.NewMedication medicationToCreate)
        {
            var result = await _medicationBL.CreateMedication(medicationToCreate);
            return new ObjectResult(result);
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteMedication(int medicationId)
        {
            var result = await _medicationBL.DeleteMedication(medicationId);
            return new ObjectResult(result);
        }


    }
}