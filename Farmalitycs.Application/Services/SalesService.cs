using Farmalitycs.Application.Contracts;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Context;
using Farmalitycs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmalitycs.Application.Services
{
    public class SalesService : ISalesService
    {
        private readonly FarmalitycsContext _context;
        public SalesService(FarmalitycsContext context) => _context = context;

        public async Task<IEnumerable<SaleDto>> GetAllAsync() =>
            await _context.Sales
                .Select(s => new SaleDto
                {
                    Id = s.Id,
                    PrescriptionId = s.PrescriptionId,
                    SaleDate = s.SaleDate,
                    TotalAmount = s.TotalAmount
                }).ToListAsync();

        public async Task<SaleDto> GetByIdAsync(int id)
        {
            var s = await _context.Sales.FindAsync(id);
            if (s == null) return null;
            return new SaleDto
            {
                Id = s.Id,
                PrescriptionId = s.PrescriptionId,
                SaleDate = s.SaleDate,
                TotalAmount = s.TotalAmount
            };
        }

        public async Task AddAsync(SaleDto dto)
        {
            var s = new Sale
            {
                PrescriptionId = dto.PrescriptionId,
                SaleDate = dto.SaleDate,
                TotalAmount = dto.TotalAmount
            };
            _context.Sales.Add(s);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SaleDto dto)
        {
            var s = await _context.Sales.FindAsync(dto.Id);
            if (s == null) return;
            s.PrescriptionId = dto.PrescriptionId;
            s.SaleDate = dto.SaleDate;
            s.TotalAmount = dto.TotalAmount;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var s = await _context.Sales.FindAsync(id);
            if (s == null) return;
            _context.Sales.Remove(s);
            await _context.SaveChangesAsync();
        }
    }
}
