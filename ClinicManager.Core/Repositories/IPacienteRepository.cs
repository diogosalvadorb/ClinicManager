using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente> GetById(int id);
        Task<Paciente> GetByCPF(string name);
        Task<Paciente> GetByTelefone(string telefone);
        Task<Paciente> AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task RemoverAsync(int id);
    }
}
