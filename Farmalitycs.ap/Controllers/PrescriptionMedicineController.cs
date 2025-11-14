using Microsoft.AspNetCore.Mvc;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.ap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionMedicineController : ControllerBase
    {
        private readonly IPrescriptionRepository _prescriptionRepo;
        private readonly IMedicineRepository _medicineRepo;

        public PrescriptionMedicineController(
            IPrescriptionRepository prescriptionRepo,
            IMedicineRepository medicineRepo)
        {
            _prescriptionRepo = prescriptionRepo;
            _medicineRepo = medicineRepo;
        }

        
        [HttpGet("{prescriptionId}")]
        public async Task<IActionResult> GetMedicinesByPrescription(int prescriptionId)
        {
            var prescription = await _prescriptionRepo.GetByIdAsync(prescriptionId);
            if (prescription == null)
                return NotFound();

            return Ok(prescription.Medicines);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddMedicineToPrescription([FromBody] PrescriptionMedicineDto dto)
        {
            var prescription = await _prescriptionRepo.GetByIdAsync(dto.PrescriptionId);
            if (prescription == null)
                return NotFound("Prescription not found");

            var medicine = await _medicineRepo.GetByIdAsync(dto.MedicineId);
            if (medicine == null)
                return NotFound("Medicine not found");

            if (!prescription.Medicines.Contains(medicine))
                prescription.Medicines.Add(medicine);

            await _prescriptionRepo.UpdateAsync(prescription);

            return Ok(prescription);
        }

        
        [HttpDelete]
        public async Task<IActionResult> RemoveMedicineFromPrescription([FromBody] PrescriptionMedicineDto dto)
        {
            var prescription = await _prescriptionRepo.GetByIdAsync(dto.PrescriptionId);
            if (prescription == null)
                return NotFound("Prescription not found");

            var medicine = prescription.Medicines.Find(m => m.Id == dto.MedicineId);
            if (medicine == null)
                return NotFound("Medicine not found in prescription");

            prescription.Medicines.Remove(medicine);
            await _prescriptionRepo.UpdateAsync(prescription);

            return NoContent();
        }
    }

    
    public class PrescriptionMedicineDto
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
    }
}
