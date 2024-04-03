using AutoMapper;
using ClinicManager.Application.DTOs.Servico;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;
        public ServicoService(IServicoRepository servicoRepository,
                              IMapper mapper)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServicoDTO>> GetAll()
        {
            try
            {
                var servicos = await _servicoRepository.GetAll();
                if (servicos == null) return Enumerable.Empty<ServicoDTO>(); ;

                var resultado = _mapper.Map<IEnumerable<ServicoDTO>>(servicos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicoDTO> GetById(Guid id)
        {
            try
            {
                var servico = await _servicoRepository.GetById(id);
                if (servico == null) return null;

                var resultado = _mapper.Map<ServicoDTO>(servico);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicoDTO> AddAsync(ServicoDTO servico)
        {
            try
            {
                var adicionarServico = _mapper.Map<Servico>(servico);
                var adicionarServicoEntidade = await _servicoRepository.AddAsync(adicionarServico);

                var retornoServicoDto = _mapper.Map<ServicoDTO>(adicionarServicoEntidade);

                return retornoServicoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServicoUpdateDTO> UpdateAsync(Guid id, ServicoUpdateDTO servico)
        {
            try
            {
                var buscaServico = await _servicoRepository.GetById(id);
                if (buscaServico == null) throw new Exception("Serviço para atualizar não encontrado.");

                _mapper.Map(servico, buscaServico);

                await _servicoRepository.UpdateAsync(buscaServico);

                return _mapper.Map<ServicoUpdateDTO>(buscaServico);
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
                var servico = await _servicoRepository.GetById(id);
                if (servico == null) throw new Exception("Serviço para remover não encontrado.");

                await _servicoRepository.RemoveAsync(servico.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
