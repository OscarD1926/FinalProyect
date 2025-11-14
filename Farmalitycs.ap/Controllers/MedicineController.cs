using Microsoft.AspNetCore.Mvc;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Farmalitycs.ap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _repo;

        public MedicineController(IMedicineRepository repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Medicine> medicines = await _repo.GetAllAsync();
            return Ok(medicines);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Medicine medicine = await _repo.GetByIdAsync(id);
            if (medicine == null) return NotFound();
            return Ok(medicine);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medicine medicine)
        {
            if (medicine == null)
                return BadRequest("Medicine cannot be null");

            await _repo.AddAsync(medicine);
            return CreatedAtAction(nameof(GetById), new { id = medicine.Id }, medicine);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medicine medicine)
        {
            if (medicine == null)
                return BadRequest("Medicine cannot be null");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = medicine.Name;
            existing.Type = medicine.Type;
            existing.ExpirationDate = medicine.ExpirationDate;
            existing.StockQuantity = medicine.StockQuantity;

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


