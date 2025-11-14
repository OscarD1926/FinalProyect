using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Farmalitycs.Domain.Entities;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Infrastructure.Context;

namespace Farmalitycs.Infrastructure.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly FarmalitycsContext _context;

        public PrescriptionRepository(FarmalitycsContext context)
        {
            _context = context;
        }

        public async Task<List<Prescription>> GetAllAsync()
        {
            return await _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Medicines)
                .ToListAsync();
        }

        public async Task<Prescription?> GetByIdAsync(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Medicines)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Prescription entity)
        {
            await _context.Prescriptions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prescription entity)
        {
            _context.Prescriptions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Prescriptions.FindAsync(id);
            if (entity != null)
            {
                _context.Prescriptions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

