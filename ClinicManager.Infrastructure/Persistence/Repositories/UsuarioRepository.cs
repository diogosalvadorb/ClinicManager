using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClinicManagerDbContext _context;
        public UsuarioRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetById(Guid id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetUsuarioByLoginAndSenhaAsync(string login, string hashSenha)
        {
            return await _context
                .Usuarios
                .SingleOrDefaultAsync(u => u.Login == login && u.Senha == hashSenha);
        }
        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

    }
}
