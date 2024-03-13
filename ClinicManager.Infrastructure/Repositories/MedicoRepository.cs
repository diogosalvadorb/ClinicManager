using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public Task<IEnumerable<Medico>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Medico> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> AddAsync(Medico medico)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Medico medico)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
