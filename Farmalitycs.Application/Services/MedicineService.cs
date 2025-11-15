using Farmalitycs.Application.Contract;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repo;

        public MedicineService(IMedicineRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MedicineDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(m => new MedicineDto
            {
                Id = m.Id,
                Name = m.Name,
                Type = m.Type,
                ExpirationDate = m.ExpirationDate,
                StockQuantity = m.StockQuantity
            }).ToList();
        }

        public async Task<MedicineDto> GetByIdAsync(int id)
        {
            var m = await _repo.GetByIdAsync(id);
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

        public async Task<MedicineDto> CreateAsync(MedicineDto dto)
        {
            var entity = new Medicine
            {
                Name = dto.Name,
                Type = dto.Type,
                ExpirationDate = dto.ExpirationDate,
                StockQuantity = dto.StockQuantity
            };
            await _repo.AddAsync(entity);
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, MedicineDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.Name = dto.Name;
            entity.Type = dto.Type;
            entity.ExpirationDate = dto.ExpirationDate;
            entity.StockQuantity = dto.StockQuantity;

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
