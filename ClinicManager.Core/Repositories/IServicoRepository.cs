using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> GetAll();
        Task<Servico> GetById(Guid id);
        Task<Servico> AddAsync(Servico servico);
        Task UpdateAsync(Servico servico);
        Task RemoveAsync(Guid id);
    }
}
