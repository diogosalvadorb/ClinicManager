using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ClinicManager.Infrastructure.Persistence
{
    public class ClinicManagerDbContext : DbContext
    {
        public ClinicManagerDbContext(DbContextOptions<ClinicManagerDbContext> options) : base(options) { }

        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
