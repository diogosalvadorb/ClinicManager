using ClinicManager.Application.DTOs.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.DTOs
{
    public class AtendimentoUpdateDTO
    {
        public PacienteDTO? Paciente { get; set; }
        public ServicoDTO? Servico { get; set; }
        public MedicoDTO? Medico { get; set; }
        public string Convenio { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ETipoAtendimentoDTO TipoAtendimento { get; set; }
    }
}
