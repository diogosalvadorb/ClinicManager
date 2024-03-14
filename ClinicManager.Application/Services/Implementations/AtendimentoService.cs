using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Implementations
{
    public class AtendimentoService : IAtendimentoService
    {
        public Task<Atendimento> AddAsync(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Atendimento>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Atendimento> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Atendimento atendimento)
        {
            throw new NotImplementedException();
        }
    }
}
