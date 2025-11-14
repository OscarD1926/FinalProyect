using Microsoft.AspNetCore.Mvc;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.ap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _repo;

        public SaleController(ISaleRepository repo)
        {
            _repo = repo;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Sale> sales = await _repo.GetAllAsync();
            return Ok(sales);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Sale sale = await _repo.GetByIdAsync(id);
            if (sale == null) return NotFound();
            return Ok(sale);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Sale sale)
        {
            if (sale == null)
                return BadRequest("Sale cannot be null");

            await _repo.AddAsync(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale.Id }, sale);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Sale sale)
        {
            if (sale == null)
                return BadRequest("Sale cannot be null");

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.PrescriptionId = sale.PrescriptionId;
            existing.SaleDate = sale.SaleDate;
            existing.TotalAmount = sale.TotalAmount;

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

