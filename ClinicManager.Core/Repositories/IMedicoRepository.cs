using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAll();
        Task<Medico> GetById(int id);
        Task<Medico> AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task RemoverAsync(int id);
    }
}
