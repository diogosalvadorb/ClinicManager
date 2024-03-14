using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<Medico>> GetAll();
        Task<Medico> GetById(Guid id);
        Task<Medico> AddAsync(Medico medico);
        Task UpdateAsync(Medico medico);
        Task RemoverAsync(Guid id);
    }
}
