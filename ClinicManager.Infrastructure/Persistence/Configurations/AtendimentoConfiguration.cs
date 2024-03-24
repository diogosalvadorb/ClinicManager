using ClinicManager.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.Configurations
{
    public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(p => p.Paciente)
                .WithMany()
                .HasForeignKey(x => x.IdPaciente);

            builder
                 .HasOne(s => s.Servico)
                 .WithMany()
                 .HasForeignKey(x => x.IdServico);

            builder
                .HasOne(p => p.Medico)
                .WithMany()
                .HasForeignKey(x => x.IdMedico);
        }
    }
}
