using Farmalitycs.Application.Dtos;

namespace Farmalitycs.Application.Contracts
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDto>> GetAllAsync();
        Task<PrescriptionDto> GetByIdAsync(int id);
        Task AddAsync(PrescriptionDto dto);
        Task UpdateAsync(PrescriptionDto dto);
        Task DeleteAsync(int id);
    }
}
