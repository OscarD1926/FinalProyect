using Farmalitycs.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Contract
{
    public interface IMedicineService
    {
        Task<List<MedicineDto>> GetAllAsync();
        Task<MedicineDto> GetByIdAsync(int id);
        Task<MedicineDto> CreateAsync(MedicineDto dto);
        Task<bool> UpdateAsync(int id, MedicineDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
