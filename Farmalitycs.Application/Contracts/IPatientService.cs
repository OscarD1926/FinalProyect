using Farmalitycs.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmalitycs.Application.Contract
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(int id);
        Task<PatientDto> CreateAsync(PatientDto dto);
        Task<bool> UpdateAsync(int id, PatientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}


