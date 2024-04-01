using ClinicManager.Application.DTOs;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDTO>> GetAll();
        Task<PacienteDTO> GetById(Guid id);
        Task<PacienteDTO> GetByCPF(string cpf);
        Task<PacienteDTO> GetByTelefone(string telefone);
        Task<PacienteDTO> AddAsync(PacienteDTO paciente);
        Task<PacienteUpdateDTO> UpdateAsync(Guid id, PacienteUpdateDTO paciente);
        Task RemoveAsync(Guid id);
    }
}
