using Farmalitycs.Application.Contracts;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Context;
using Farmalitycs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmalitycs.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly FarmalitycsContext _context;

        public MedicineService(FarmalitycsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicineDto>> GetAllAsync() =>
            await _context.Medicines
                .Select(m => new MedicineDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Type = m.Type,
                    ExpirationDate = m.ExpirationDate,
                    StockQuantity = m.StockQuantity
                }).ToListAsync();

        public async Task<MedicineDto> GetByIdAsync(int id)
        {
            var m = await _context.Medicines.FindAsync(id);
            if (m == null) return null;
            return new MedicineDto
            {
                Id = m.Id,
                Name = m.Name,
                Type = m.Type,
                ExpirationDate = m.ExpirationDate,
                StockQuantity = m.StockQuantity
            };
        }

        public async Task AddAsync(MedicineDto dto)
        {
            var m = new Medicine
            {
                Name = dto.Name,
                Type = dto.Type,
                ExpirationDate = dto.ExpirationDate,
                StockQuantity = dto.StockQuantity
            };
            _context.Medicines.Add(m);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicineDto dto)
        {
            var m = await _context.Medicines.FindAsync(dto.Id);
            if (m == null) return;
            m.Name = dto.Name;
            m.Type = dto.Type;
            m.ExpirationDate = dto.ExpirationDate;
            m.StockQuantity = dto.StockQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var m = await _context.Medicines.FindAsync(id);
            if (m == null) return;
            _context.Medicines.Remove(m);
            await _context.SaveChangesAsync();
        }
    }
}