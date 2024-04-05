using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IAuthService _authService;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ClinicManagerDbContext _context;

        public UsuarioService(IAuthService authService, UsuarioRepository usuarioRepository, ClinicManagerDbContext context)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario user)
        {
            try
            {
                var hashSenha = _authService.ComputeSha256Hash(user.Senha);

                var novoUsuario = new Usuario(user.Login, hashSenha, user.Ativo, user.Perfil);

                await _context.Usuarios.AddAsync(novoUsuario);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> GetById(Guid id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetById(id);
                if (usuario == null) return null; 

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

