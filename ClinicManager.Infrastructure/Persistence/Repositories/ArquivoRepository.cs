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

        public async Task UpdateAsync(Arquivo arquivo)
        {
            var retornoArquivo = await _context.Arquivos.FindAsync(arquivo.Id);
            if(retornoArquivo == null)
                throw new ArgumentException("Arquivo para atualizar não encontrado.");

            _context.Entry(retornoArquivo).CurrentValues.SetValues(arquivo);

            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var retornoArquivo = await _context.Arquivos.FindAsync(id);

            if (retornoArquivo == null)
            {
                throw new ArgumentException($"Arquivo não encontrado");
            }

            _context.Arquivos.Remove(retornoArquivo);
            await _context.SaveChangesAsync();
        }
    }
}
