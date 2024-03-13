using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        public Task<IEnumerable<Atendimento>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Atendimento> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Atendimento> AddAsync(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
