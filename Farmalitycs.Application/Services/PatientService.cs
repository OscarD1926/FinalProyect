using Farmalitycs.Application.Contract;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PatientDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(p => new PatientDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Identification = p.Identification,
                Phone = p.Phone,
                PrescriptionsIds = p.Prescriptions.Select(pr => pr.Id).ToList()
            }).ToList();
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new PatientDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Identification = p.Identification,
                Phone = p.Phone,
                PrescriptionsIds = p.Prescriptions.Select(pr => pr.Id).ToList()
            };
        }

        public async Task<PatientDto> CreateAsync(PatientDto dto)
        {
            var entity = new Patient
            {
                FullName = dto.FullName,
                Identification = dto.Identification,
                Phone = dto.Phone
            };
            await _repo.AddAsync(entity);
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, PatientDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.FullName = dto.FullName;
            entity.Identification = dto.Identification;
            entity.Phone = dto.Phone;

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
