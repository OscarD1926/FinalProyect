using Farmalitycs.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Contract
{
    public interface IPrescriptionService
    {
        Task<List<PrescriptionDto>> GetAllAsync();
        Task<PrescriptionDto> GetByIdAsync(int id);
        Task<PrescriptionDto> CreateAsync(PrescriptionDto dto);
        Task<bool> UpdateAsync(int id, PrescriptionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

