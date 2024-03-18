using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public Task<IEnumerable<Medico>> GetAll()
        {
            try
            {
                var medicos = _medicoRepository.GetAll();
                if (medicos == null) return null;

                return medicos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Medico> GetById(Guid id)
        {
            try
            {
                var medico = _medicoRepository.GetById(id);
                if (medico == null) return null; 
                
                return medico;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Medico> AddAsync(Medico medico)
        {
            try
            {
                var adicionarMedico = await _medicoRepository.AddAsync(medico);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Medico medico)
        {
            try
            {
                var buscaMedico = await _medicoRepository.GetById(medico.Id);
                if (buscaMedico == null) throw new Exception("Médico para atualizar não encontrado.");

                medico.Id = buscaMedico.Id;

                await _medicoRepository.UpdateAsync(medico);
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
                var medico = await _medicoRepository.GetById(id);
                if (medico == null) throw new Exception("Médico para remover não encontrado.");

                await _medicoRepository.RemoverAsync(medico.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
