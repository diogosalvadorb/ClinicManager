using ClinicManager.Application.DTOs.Atendimento;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IAtendimentoService
    {
        Task<IEnumerable<AtendimentoDTO>> GetAll();
        Task<AtendimentoDTO> GetById(Guid id);
        Task<AtendimentoDTO> AddAsync(AtendimentoDTO atendimento);
        Task<AtendimentoUpdateDTO> UpdateAsync(Guid id, AtendimentoUpdateDTO atendimento);
        Task RemoveAsync(Guid id);
    }
}
