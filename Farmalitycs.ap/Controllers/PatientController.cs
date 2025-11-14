using Microsoft.AspNetCore.Mvc;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.ap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repo;

        public PatientController(IPatientRepository repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Patient> patients = await _repo.GetAllAsync();
            return Ok(patients);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Patient patient = await _repo.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest("Patient cannot be null");

            await _repo.AddAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest("Patient cannot be null");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.FullName = patient.FullName;
            existing.Identification = patient.Identification;
            existing.Phone = patient.Phone;

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


