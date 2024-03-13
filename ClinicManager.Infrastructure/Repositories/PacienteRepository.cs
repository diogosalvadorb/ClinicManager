using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public Task<IEnumerable<Paciente>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetByCPF(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> GetByTelefone(string telefone)
        {
            throw new NotImplementedException();
        }

        public Task<Paciente> AddAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
