using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Implementations
{
    public class PacienteService : IPacienteService
    {
        public Task<Paciente> AddAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Paciente>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetByTelefone(string telefone)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
