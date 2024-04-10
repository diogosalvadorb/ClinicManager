using ClinicManager.Application.DTOs.Usuario;
using ClinicManager.Core.Entities;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IUsuarioService
    {

        Task<UsuarioDTO> AddAsync(UsuarioDTO usuario);
        Task<UsuarioDTO> GetById(Guid id);
        Task<UsuarioDTO> GetUsuarioByLoginAndSenhaAsync(string login, string hashSenha);
    }
}
