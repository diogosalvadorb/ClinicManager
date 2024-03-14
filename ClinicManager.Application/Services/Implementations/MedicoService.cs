using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoService _medicoService;
        public MedicoService(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        public Task<IEnumerable<Medico>> GetAll()
        {
            try
            {
                var medicos = _medicoService.GetAll();
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
                var medico = _medicoService.GetById(id);
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
                var adicionarMedico = await _medicoService.AddAsync(medico);
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
                var buscaMedico = await _medicoService.GetById(medico.Id);
                if (buscaMedico == null) throw new Exception("Médico para atualizar não encontrado.");

                await _medicoService.UpdateAsync(medico);
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
                var medico = await _medicoService.GetById(id);
                if (medico == null) throw new Exception("Médico para remover não encontrado.");

                await _medicoService.RemoverAsync(medico.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
