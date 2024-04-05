using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetById(Guid id);
        Task<Usuario> GetUsuarioByLoginAndSenhaAsync(string login, string hashSenha);
    }
}
