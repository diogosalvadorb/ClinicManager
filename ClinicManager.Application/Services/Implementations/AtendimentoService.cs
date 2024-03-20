using AutoMapper;
using ClinicManager.Application.DTOs;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IMapper _mapper;
        public AtendimentoService(IAtendimentoRepository atendimentoRepository,
                                  IMapper mapper)
        {
            _atendimentoRepository = atendimentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AtendimentoDTO>> GetAll()
        {
            try
            {
                var atendimentos = await _atendimentoRepository.GetAll();
                if (atendimentos == null) return null;

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
                if (atendimento == null) return null;

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

                var adicionarAtendimentoDTO = await _atendimentoRepository.AddAsync(adicionarAtendimento);

                return null;
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

        public async Task RemoverAsync(Guid id)
        {
            try
            {
                var buscaAtendimento = _atendimentoRepository.GetById(id);
                if (buscaAtendimento == null) throw new Exception("Atendimento para remover não encontrado.");

                await _atendimentoRepository.RemoverAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
