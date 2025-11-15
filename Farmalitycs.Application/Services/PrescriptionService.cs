using Farmalitycs.Application.Contracts;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Context;
using Farmalitycs.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmalitycs.Application.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly FarmalitycsContext _context;
        public PrescriptionService(FarmalitycsContext context) => _context = context;

        public async Task<IEnumerable<PrescriptionDto>> GetAllAsync() =>
            await _context.Prescriptions
                .Select(p => new PrescriptionDto
                {
                    Id = p.Id,
                    PatientId = p.PatientId,
                    MedicineId = p.MedicineId,
                    IssueDate = p.IssueDate,
                    Instructions = p.Instructions,
                    MedicineIds = p.Medicines.Select(m => m.Id).ToList()
                }).ToListAsync();

        public async Task<PrescriptionDto> GetByIdAsync(int id)
        {
            var p = await _context.Prescriptions
                .Include(p => p.Medicines)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (p == null) return null;
            return new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                MedicineId = p.MedicineId,
                IssueDate = p.IssueDate,
                Instructions = p.Instructions,
                MedicineIds = p.Medicines.Select(m => m.Id).ToList()
            };
        }

        public async Task AddAsync(PrescriptionDto dto)
        {
            var p = new Prescription
            {
                PatientId = dto.PatientId,
                MedicineId = dto.MedicineId,
                IssueDate = dto.IssueDate,
                Instructions = dto.Instructions
            };

            if (dto.MedicineIds != null && dto.MedicineIds.Any())
            {
                p.Medicines = await _context.Medicines
                    .Where(m => dto.MedicineIds.Contains(m.Id))
                    .ToListAsync();
            }

            _context.Prescriptions.Add(p);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PrescriptionDto dto)
        {
            var p = await _context.Prescriptions
                .Include(p => p.Medicines)
                .FirstOrDefaultAsync(p => p.Id == dto.Id);
            if (p == null) return;

            p.PatientId = dto.PatientId;
            p.MedicineId = dto.MedicineId;
            p.IssueDate = dto.IssueDate;
            p.Instructions = dto.Instructions;

            if (dto.MedicineIds != null)
            {
                p.Medicines = await _context.Medicines
                    .Where(m => dto.MedicineIds.Contains(m.Id))
                    .ToListAsync();
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _context.Prescriptions.FindAsync(id);
            if (p == null) return;
            _context.Prescriptions.Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}
