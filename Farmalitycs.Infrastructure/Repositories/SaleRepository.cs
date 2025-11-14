using Farmalitycs.Domain.Entities;
using Farmalitycs.Infrastructure.Context;
using Farmalitycs.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly FarmalitycsContext _context;

        public SaleRepository(FarmalitycsContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task<Sale?> GetByIdAsync(int id)
        {
            return await _context.Sales.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}

