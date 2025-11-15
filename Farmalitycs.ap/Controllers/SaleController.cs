using Microsoft.AspNetCore.Mvc;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Application.Contracts;
using System.Threading.Tasks;

namespace Farmalitycs.ap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _service.GetByIdAsync(id);

            if (sale == null)
                return NotFound("No existe una venta con el ID {id}");

            return Ok(sale);
        }

      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);    

            var created = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound("No existe una venta con el ID {id}");

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound("No existe una venta con el ID {id}");

            return NoContent();
        }
    }
}
