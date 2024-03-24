using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ClinicManagerDbContext _context;
        public AtendimentoRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Atendimento>> GetAll()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        public async Task<Atendimento> GetById(Guid id)
        {
            return await _context.Atendimentos
                .Include(m => m.Medico)
                .Include(p => p.Paciente)
                .Include(s => s.Servico)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Atendimento> AddAsync(Atendimento atendimento)
        {
            try
            {
                await _context.Atendimentos.AddAsync(atendimento);
                await _context.SaveChangesAsync();
                return atendimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            var retornoAtendimento = await _context.Atendimentos.FindAsync(atendimento.Id);

            if (retornoAtendimento == null)
            {
                throw new ArgumentException($"Serviço não encontrado");
            }

            _context.Entry(retornoAtendimento).CurrentValues.SetValues(atendimento);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var retornoAtendimento = await _context.Atendimentos.FindAsync(id);

            if (retornoAtendimento == null)
            {
                throw new ArgumentException($"Serviço não encontrado");
            }

            _context.Atendimentos.Remove(retornoAtendimento);
            await _context.SaveChangesAsync();
        }
    }
}
