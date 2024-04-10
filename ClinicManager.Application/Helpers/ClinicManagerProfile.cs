using AutoMapper;
using ClinicManager.Application.DTOs.Arquivo;
using ClinicManager.Application.DTOs.Atendimento;
using ClinicManager.Application.DTOs.Enum;
using ClinicManager.Application.DTOs.Medico;
using ClinicManager.Application.DTOs.Paciente;
using ClinicManager.Application.DTOs.Servico;
using ClinicManager.Application.DTOs.Usuario;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;

namespace ClinicManager.Application.Helpers
{
    public class ClinicManagerProfile : Profile
    {
        public ClinicManagerProfile()
        {
            CreateMap<Atendimento, AtendimentoDTO>().ReverseMap();
            CreateMap<Atendimento, AtendimentoUpdateDTO>().ReverseMap();

            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Medico, MedicoUpdateDTO>().ReverseMap();

            CreateMap<Paciente, PacienteDTO>().ReverseMap();
            CreateMap<Paciente, PacienteUpdateDTO>().ReverseMap();

            CreateMap<Servico, ServicoDTO>().ReverseMap();
            CreateMap<Servico, ServicoUpdateDTO>().ReverseMap();

            CreateMap<Arquivo, ArquivoDTO>().ReverseMap();
            CreateMap<Arquivo, ArquivoUpdateDTO>().ReverseMap();

            CreateMap<Usuario, LoginDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            CreateMap<ETipoAtendimento, ETipoAtendimentoDTO>().ReverseMap();
        }
    }
}
