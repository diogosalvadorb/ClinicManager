using AutoMapper;
using ClinicManager.Application.DTOs;
using ClinicManager.Application.DTOs.Enum;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;

namespace ClinicManager.Application.Helpers
{
    public class ClinicManagerProfile : Profile
    {
        public ClinicManagerProfile()
        {
            CreateMap<Atendimento, AtendimentoDTO>().ReverseMap();
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Medico, MedicoUpdateDTO>().ReverseMap();
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Servico, ServicoDTO>().ReverseMap();
            CreateMap<Arquivo, ArquivoDTO>().ReverseMap();
            CreateMap<Arquivo, ArquivoUpdateDTO>().ReverseMap();
            CreateMap<ETipoAtendimento, ETipoAtendimentoDTO>().ReverseMap();
        }
    }
}
