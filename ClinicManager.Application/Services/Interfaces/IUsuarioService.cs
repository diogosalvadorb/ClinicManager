using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IUsuarioService
    {

        Task<Usuario> AddAsync(Usuario user);
        Task<Usuario> GetById(Guid id);
    }
}
