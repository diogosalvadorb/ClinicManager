using ClinicManager.Application.DTOs.Enum;

namespace ClinicManager.Application.DTOs
{
    public class AtendimentoDTO
    {
        public Guid IdPaciente { get; set; }
        public Guid IdServico { get; set; }
        public Guid IdMedico { get; set; }

        public PacienteDTO? Paciente { get; set; }
        public ServicoDTO? Servico { get; set; }
        public MedicoDTO? Medico { get; set; }
        public string Convenio { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ETipoAtendimentoDTO TipoAtendimento { get; set; }
    }
}
