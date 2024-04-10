using ClinicManager.Application.DTOs.Medico;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDTO>> GetAll();
        Task<MedicoDTO> GetById(Guid id);
        Task<MedicoDTO> AddAsync(MedicoDTO medico);
        Task<MedicoUpdateDTO> UpdateAsync(Guid id, MedicoUpdateDTO medico);
        Task RemoveAsync(Guid id);
    }
}
