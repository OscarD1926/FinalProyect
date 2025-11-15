using Farmalitycs.Application.Contract;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repo;
        private readonly IMedicineRepository _medicineRepo;

        public PrescriptionService(IPrescriptionRepository repo, IMedicineRepository medicineRepo)
        {
            _repo = repo;
            _medicineRepo = medicineRepo;
        }

        public async Task<List<PrescriptionDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(p => new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                MedicineId = p.MedicineId,
                IssueDate = p.IssueDate,
                Instructions = p.Instructions,
                MedicinesIds = p.Medicines.Select(m => m.Id).ToList()
            }).ToList();
        }

        public async Task<PrescriptionDto> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                MedicineId = p.MedicineId,
                IssueDate = p.IssueDate,
                Instructions = p.Instructions,
                MedicinesIds = p.Medicines.Select(m => m.Id).ToList()
            };
        }

        public async Task<PrescriptionDto> CreateAsync(PrescriptionDto dto)
        {
            var entity = new Prescription
            {
                PatientId = dto.PatientId,
                MedicineId = dto.MedicineId,
                IssueDate = dto.IssueDate,
                Instructions = dto.Instructions
            };

            // Relación Many-to-Many
            if (dto.MedicinesIds != null && dto.MedicinesIds.Count > 0)
            {
                foreach (var medId in dto.MedicinesIds)
                {
                    var med = await _medicineRepo.GetByIdAsync(medId);
                    if (med != null)
                        entity.Medicines.Add(med);
                }
            }

            await _repo.AddAsync(entity);
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, PrescriptionDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.PatientId = dto.PatientId;
            entity.MedicineId = dto.MedicineId;
            entity.IssueDate = dto.IssueDate;
            entity.Instructions = dto.Instructions;

            // Actualizar relación Many-to-Many
            entity.Medicines.Clear();
            if (dto.MedicinesIds != null && dto.MedicinesIds.Count > 0)
            {
                foreach (var medId in dto.MedicinesIds)
                {
                    var med = await _medicineRepo.GetByIdAsync(medId);
                    if (med != null)
                        entity.Medicines.Add(med);
                }
            }

            await _repo.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            await _repo.DeleteAsync(id);
            return true;
        }
    }
}
