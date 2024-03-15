using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public Task<IEnumerable<Atendimento>> GetAll()
        {
            try
            {
                var atendimentos = _atendimentoRepository.GetAll();
                if (atendimentos == null) return null; 
                
                return atendimentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Atendimento> GetById(Guid id)
        {
            try
            {
                var atendimento = _atendimentoRepository.GetById(id);
                if (atendimento == null) return null;

                return atendimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Atendimento> AddAsync(Atendimento atendimento)
        {
            try
            {
                var adicionarAtendimento = _atendimentoRepository.AddAsync(atendimento);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            try
            {
                var buscarAtendimento = await _atendimentoRepository.GetById(atendimento.Id);
                if (buscarAtendimento == null) throw new Exception("Atendimento para atualizar não encontrado.");

                await _atendimentoRepository.UpdateAsync(atendimento);
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
