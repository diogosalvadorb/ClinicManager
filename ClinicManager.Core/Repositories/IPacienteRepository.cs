using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente> GetById(Guid id);
        Task<Paciente> GetByCPF(string cpf);
        Task<Paciente> GetByTelefone(string telefone);
        Task<Paciente> AddAsync(Paciente paciente);
        Task<string> GetEmail(Guid id);
        Task UpdateAsync(Paciente paciente);
        Task RemoveAsync(Guid id);
    }
}
