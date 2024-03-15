using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using ClinicManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicManagerDbContext _context;
        public MedicoRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetAll()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico> GetById(Guid id)
        {
            return await _context.Medicos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Medico> AddAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task UpdateAsync(Medico medico)
        {
            var retornoMedico = await _context.Medicos.FindAsync(medico.Id);

            if (retornoMedico == null)
            {
                throw new ArgumentException($"Médico não encontrado");
            }

            _context.Medicos.Update(medico);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var retornoMedico = await _context.Medicos.FindAsync(id);

            if (retornoMedico == null)
            {
                throw new ArgumentException($"Médico não encontrado");
            }

            _context.Medicos.Remove(retornoMedico);
            await _context.SaveChangesAsync();
        }
    }
}
