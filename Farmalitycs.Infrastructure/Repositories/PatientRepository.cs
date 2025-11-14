
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Farmalitycs.Domain.Entities;
using Farmalitycs.Infrastructure.Interfaces;


using Farmalitycs.Infrastructure.Context;

namespace Farmalitycs.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly FarmalitycsContext _context;

        public PatientRepository(FarmalitycsContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task AddAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Patients.FindAsync(id);
            if (item != null)
            {
                _context.Patients.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
