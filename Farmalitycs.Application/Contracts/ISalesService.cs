using Farmalitycs.Application.Dtos;

namespace Farmalitycs.Application.Contracts
{
    public interface ISalesService
    {
        Task<IEnumerable<SaleDto>> GetAllAsync();
        Task<SaleDto> GetByIdAsync(int id);
        Task AddAsync(SaleDto dto);
        Task UpdateAsync(SaleDto dto);
        Task DeleteAsync(int id);
    }
}