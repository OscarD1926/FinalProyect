using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Farmalitycs.Domain.Entities;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Infrastructure.Context;

namespace Farmalitycs.Infrastructure.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly FarmalitycsContext _context;

        public MedicineRepository(FarmalitycsContext context)
        {
            _context = context;
        }

        public async Task<List<Medicine>> GetAllAsync()
        {
            return await _context.Medicines.ToListAsync();
        }

        public async Task<Medicine> GetByIdAsync(int id)
        {
            return await _context.Medicines.FindAsync(id);
        }

        public async Task AddAsync(Medicine entity)
        {
            await _context.Medicines.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medicine entity)
        {
            _context.Medicines.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Medicines.FindAsync(id);
            if (item != null)
            {
                _context.Medicines.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}

