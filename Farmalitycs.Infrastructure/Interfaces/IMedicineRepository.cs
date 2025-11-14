using Farmalitycs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.Infrastructure.Interfaces
{
    public interface IMedicineRepository
    {
        Task<List<Medicine>> GetAllAsync();
        Task<Medicine?> GetByIdAsync(int id);
        Task AddAsync(Medicine medicine);
        Task UpdateAsync(Medicine medicine);
        Task DeleteAsync(int id);
    }
}
