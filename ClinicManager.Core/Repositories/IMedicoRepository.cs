using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAll();
        Task<Medico> GetById(Guid id);
        Task<Medico> AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task RemoveAsync(Guid id);
    }
}
