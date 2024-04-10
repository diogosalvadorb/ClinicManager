using ClinicManager.Application.DTOs.Servico;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IServicoService
    {
        Task<IEnumerable<ServicoDTO>> GetAll();
        Task<ServicoDTO> GetById(Guid id);
        Task<ServicoDTO> AddAsync(ServicoDTO servico);
        Task<ServicoUpdateDTO> UpdateAsync(Guid id, ServicoUpdateDTO servico);
        Task RemoveAsync(Guid id);
    }
}
