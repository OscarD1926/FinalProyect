using Farmalitycs.Application.Contracts;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Context;
using Farmalitycs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmalitycs.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly FarmalitycsContext _context;
        public PatientService(FarmalitycsContext context) => _context = context;

        public async Task<IEnumerable<PatientDto>> GetAllAsync() =>
            await _context.Patients
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Identification = p.Identification,
                    Phone = p.Phone
                }).ToListAsync();

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var p = await _context.Patients.FindAsync(id);
            if (p == null) return null;
            return new PatientDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Identification = p.Identification,
                Phone = p.Phone
            };
        }

        public async Task AddAsync(PatientDto dto)
        {
            var p = new Patient
            {
                FullName = dto.FullName,
                Identification = dto.Identification,
                Phone = dto.Phone
            };
            _context.Patients.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PatientDto dto)
        {
            var p = await _context.Patients.FindAsync(dto.Id);
            if (p == null) return;
            p.FullName = dto.FullName;
            p.Identification = dto.Identification;
            p.Phone = dto.Phone;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _context.Patients.FindAsync(id);
            if (p == null) return;
            _context.Patients.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}