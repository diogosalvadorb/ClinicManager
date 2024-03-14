using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente> GetById(Guid id);
        Task<Paciente> GetByCPF(string cpf);
        Task<Paciente> GetByTelefone(string telefone);
        Task<Paciente> AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task RemoverAsync(Guid id);
    }
}
