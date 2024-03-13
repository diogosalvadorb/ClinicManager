using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Infrastructure.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        public Task<IEnumerable<Servico>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Servico> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Servico> AddAsync(Servico servico)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Servico servico)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
