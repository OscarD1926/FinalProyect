using Farmalitycs.Application.Contracts;
using Farmalitycs.Application.Dtos;
using Farmalitycs.Infrastructure.Interfaces;
using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repo;

        public SaleService(ISaleRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(s => new SaleDto
            {
                Id = s.Id,
                PrescriptionId = s.PrescriptionId,
                SaleDate = s.SaleDate,
                TotalAmount = s.TotalAmount
            }).ToList();
        }

        public async Task<SaleDto> GetByIdAsync(int id)
        {
            var s = await _repo.GetByIdAsync(id);
            if (s == null) return null;

            return new SaleDto
            {
                Id = s.Id,
                PrescriptionId = s.PrescriptionId,
                SaleDate = s.SaleDate,
                TotalAmount = s.TotalAmount
            };
        }

        public async Task<SaleDto> CreateAsync(SaleDto dto)
        {
            var entity = new Sale
            {
                PrescriptionId = dto.PrescriptionId,
                SaleDate = dto.SaleDate,
                TotalAmount = dto.TotalAmount
            };

            await _repo.AddAsync(entity);
            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> UpdateAsync(int id, SaleDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            entity.PrescriptionId = dto.PrescriptionId;
            entity.SaleDate = dto.SaleDate;
            entity.TotalAmount = dto.TotalAmount;

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
