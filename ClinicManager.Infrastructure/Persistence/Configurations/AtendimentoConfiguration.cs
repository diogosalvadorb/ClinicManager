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
                .WithOne()
                .HasForeignKey<Atendimento>(x => x.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict); ;

            builder
                 .HasOne(s => s.Servico)
                 .WithOne()
                 .HasForeignKey<Atendimento>(x => x.IdServico)
                 .OnDelete(DeleteBehavior.Restrict); ;

            builder
                .HasOne(p => p.Medico)
                .WithOne()
                .HasForeignKey<Atendimento>(x => x.IdMedico)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
