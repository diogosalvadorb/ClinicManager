using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicManagerDbContext _context;
        public PacienteRepository(ClinicManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetById(Guid id)
        {
            return await _context.Pacientes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Paciente> GetByCPF(string cpf)
        {
            return await _context.Pacientes.SingleOrDefaultAsync(x => x.CPF == cpf);
        }

        public async Task<Paciente> GetByTelefone(string telefone)
        {
            return await _context.Pacientes.SingleOrDefaultAsync(x => x.Telefone == telefone);
        }

        public async Task<string> GetEmail(Guid id)
        {
            var emailPaciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);

            return emailPaciente.Email;
        }

        public async Task<Paciente> AddAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            var retornoPaciente = await _context.Pacientes.FindAsync(paciente.Id);
            if (retornoPaciente == null)
                throw new ArgumentException($"Paciente para atualizar não encontrado");

            _context.Entry(retornoPaciente).CurrentValues.SetValues(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var retornoPaciente = await _context.Pacientes.FindAsync(id);

            if (retornoPaciente == null)
                throw new ArgumentException($"Paciente não encontrado");

            _context.Pacientes.Remove(retornoPaciente);
            await _context.SaveChangesAsync();
        }
    }
}
