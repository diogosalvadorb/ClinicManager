using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<IEnumerable<Atendimento>> GetAll();
        Task<Atendimento> GetById(int id);
        Task<Atendimento> AddAsync(Atendimento atendimento);
        Task UpdateAsync(Atendimento atendimento);
        Task RemoverAsync(int id);
    }
}
