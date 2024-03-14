using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IServicoService
    {
        Task<IEnumerable<Servico>> GetAll();
        Task<Servico> GetById(Guid id);
        Task<Servico> AddAsync(Servico servico);
        Task UpdateAsync(Servico servico);
        Task RemoverAsync(Guid id);
    }
}
