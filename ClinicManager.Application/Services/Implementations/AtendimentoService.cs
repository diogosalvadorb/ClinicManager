using AutoMapper;
using ClinicManager.Application.DTOs.Atendimento;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AtendimentoService(IAtendimentoRepository atendimentoRepository,
                                  IEmailService emailService,     
                                  IMapper mapper)
        {
            _atendimentoRepository = atendimentoRepository;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AtendimentoDTO>> GetAll()
        {
            try
            {
                var atendimentos = await _atendimentoRepository.GetAll();
                if (atendimentos == null) Enumerable.Empty<AtendimentoDTO>();

                var resultado = _mapper.Map<IEnumerable<AtendimentoDTO>>(atendimentos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtendimentoDTO> GetById(Guid id)
        {
            try
            {
                var atendimento = await _atendimentoRepository.GetById(id);
                if (atendimento == null) return new AtendimentoDTO();

                var resultado = _mapper.Map<AtendimentoDTO>(atendimento);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtendimentoDTO> AddAsync(AtendimentoDTO atendimento)
        {
            try
            {
                var adicionarAtendimento = _mapper.Map<Atendimento>(atendimento);

                var adicionarAtendimentoEntidade = await _atendimentoRepository.AddAsync(adicionarAtendimento);

                await _emailService.SendEmailAsync(adicionarAtendimento.IdPaciente);

                var retornoAtendimentoDTO = _mapper.Map<AtendimentoDTO>(adicionarAtendimentoEntidade);

                return retornoAtendimentoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<AtendimentoUpdateDTO> UpdateAsync(Guid id, AtendimentoUpdateDTO atendimento)
        {
            try
            {
                var buscaAtendimento = await _atendimentoRepository.GetById(id);
                if (buscaAtendimento == null) throw new Exception("Atendimento para atualizar não encontrado.");

                _mapper.Map(atendimento, buscaAtendimento);

                await _atendimentoRepository.UpdateAsync(buscaAtendimento);

                return _mapper.Map<AtendimentoUpdateDTO>(buscaAtendimento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                var buscaAtendimento = _atendimentoRepository.GetById(id);
                if (buscaAtendimento == null) throw new Exception("Atendimento para remover não encontrado.");

                await _atendimentoRepository.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
