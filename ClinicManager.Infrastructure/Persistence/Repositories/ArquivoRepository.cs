using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly ClinicManagerDbContext _context;
        public ArquivoRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Arquivo> AddAsync(Arquivo arquivo)
        {
            await _context.Arquivos.AddAsync(arquivo);
            await _context.SaveChangesAsync();
            return arquivo;
        }

        public async Task<Arquivo> GetById(Guid id)
        {
            return await _context.Arquivos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Arquivo arquivo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
