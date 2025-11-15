using Farmalitycs.Application.Dtos;

namespace Farmalitycs.Application.Contracts
{
    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDto>> GetAllAsync();
        Task<MedicineDto> GetByIdAsync(int id);
        Task AddAsync(MedicineDto dto);
        Task UpdateAsync(MedicineDto dto);
        Task DeleteAsync(int id);
    }
}