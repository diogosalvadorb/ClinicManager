using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public Task<IEnumerable<Servico>> GetAll()
        {
            try
            {
                var servicos = _servicoRepository.GetAll();
                if (servicos == null) return null;

                return servicos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Servico> GetById(Guid id)
        {
            try
            {
                var servico = _servicoRepository.GetById(id);
                if (servico == null) return null;

                return servico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Servico> AddAsync(Servico servico)
        {
            try
            {
                var adicionarServico = await _servicoRepository.AddAsync(servico);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Servico servico)
        {
            try
            {
                var buscaServico = await _servicoRepository.GetById(servico.Id);
                if (buscaServico == null) throw new Exception("Serviço para atualizar não encontrado.");

                servico.Id = buscaServico.Id;

                await _servicoRepository.UpdateAsync(servico);
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
                var servico = await _servicoRepository.GetById(id);
                if (servico == null) throw new Exception("Serviço para remover não encontrado.");

                await _servicoRepository.RemoverAsync(servico.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
