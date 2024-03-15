using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly ClinicManagerDbContext _context;
        public ServicoRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Servico>> GetAll()
        {
            return await _context.Servicos.ToListAsync();
        }

        public async Task<Servico> GetById(Guid id)
        {
            return await _context.Servicos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Servico> AddAsync(Servico servico)
        {
            await _context.Servicos.AddAsync(servico);
            await _context.SaveChangesAsync();
            return servico;
        }

        public async Task UpdateAsync(Servico servico)
        {
            var retornoServico = await _context.Medicos.FindAsync(servico.Id);

            if (retornoServico == null)
            {
                throw new ArgumentException($"Serviço não encontrado");
            }

            _context.Servicos.Update(servico);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var retornoServico = await _context.Servicos.FindAsync(id);

            if (retornoServico == null)
            {
                throw new ArgumentException($"Serviço não encontrado");
            }

            _context.Servicos.Remove(retornoServico);
            await _context.SaveChangesAsync();
        }
    }
}
