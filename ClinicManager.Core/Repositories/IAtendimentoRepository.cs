using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> GetAll();
        Task<Atendimento> GetById(Guid id);
        Task<Atendimento> AddAsync(Atendimento atendimento);
        Task UpdateAsync(Atendimento atendimento);
        Task RemoveAsync(Guid id);
    }
}
