using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IAtendimentoService
    {
        Task<IEnumerable<Atendimento>> GetAll();
        Task<Atendimento> GetById(Guid id);
        Task<Atendimento> AddAsync(Atendimento atendimento);
        Task UpdateAsync(Atendimento atendimento);
        Task RemoverAsync(Guid id);
    }
}
