using Farmalitycs.Application.Dtos;

namespace Farmalitycs.Application.Contracts
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task AddAsync(PatientDto dto);
        Task UpdateAsync(PatientDto dto);
        Task DeleteAsync(int id);
    }
}
