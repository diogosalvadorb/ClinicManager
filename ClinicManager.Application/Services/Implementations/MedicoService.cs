using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Implementations
{
    public class MedicoService : IMedicoService
    {
        public Task<Medico> AddAsync(Medico medico)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Medico>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Medico> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Medico medico)
        {
            throw new NotImplementedException();
        }
    }
}
