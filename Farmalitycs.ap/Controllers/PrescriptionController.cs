using Microsoft.AspNetCore.Mvc;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.ap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionRepository _repo;

        public PrescriptionController(IPrescriptionRepository repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Prescription> prescriptions = await _repo.GetAllAsync();
            return Ok(prescriptions);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Prescription prescription = await _repo.GetByIdAsync(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prescription prescription)
        {
            if (prescription == null)
                return BadRequest("Prescription cannot be null");

            await _repo.AddAsync(prescription);
            return CreatedAtAction(nameof(GetById), new { id = prescription.Id }, prescription);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Prescription prescription)
        {
            if (prescription == null)
                return BadRequest("Prescription cannot be null");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.PatientId = prescription.PatientId;
            existing.MedicineId = prescription.MedicineId;
            existing.Medicines = prescription.Medicines ?? new List<Medicine>();
            existing.IssueDate = prescription.IssueDate;
            existing.Instructions = prescription.Instructions;

            await _repo.UpdateAsync(existing);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}


