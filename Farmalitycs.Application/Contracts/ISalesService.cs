using Farmalitycs.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Contracts
{
    public interface ISaleService
    {
        Task<List<SaleDto>> GetAllAsync();
        Task<SaleDto> GetByIdAsync(int id);
        Task<SaleDto> CreateAsync(SaleDto dto);
        Task<bool> UpdateAsync(int id, SaleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

