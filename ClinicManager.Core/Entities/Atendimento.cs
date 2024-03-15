using ClinicManager.Core.Enums;

namespace ClinicManager.Core.Entities
{
    public class Atendimento : BaseEntity
    {
        public Guid IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
        public Guid IdServico { get; set; }
        public Servico? Servico { get; set; }
        public Guid IdMedico { get; set; }
        public Medico? Medico { get; set; }
        public string Convenio { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ETipoAtendimento TipoAtendimento { get; set; }
    }
}
