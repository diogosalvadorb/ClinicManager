using AutoMapper;
using ClinicManager.Application.DTOs;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;
        public MedicoService(IMedicoRepository medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicoDTO>> GetAll()
        {
            try
            {
                var medicos = await _medicoRepository.GetAll();
                if (medicos == null) return null;

                var resultado = _mapper.Map<IEnumerable<MedicoDTO>>(medicos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedicoDTO> GetById(Guid id)
        {
            try
            {
                var medico = await _medicoRepository.GetById(id);
                if (medico == null) return null;

                var resultado = _mapper.Map<MedicoDTO>(medico);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedicoDTO> AddAsync(MedicoDTO medico)
        {
            try
            {
                var adicionarMedico = _mapper.Map<Medico>(medico);
                var adicionarMedicoEntidade = await _medicoRepository.AddAsync(adicionarMedico);

                var retornoMedicoDTO = _mapper.Map<MedicoDTO>(adicionarMedicoEntidade);

                return retornoMedicoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MedicoUpdateDTO> UpdateAsync(Guid id, MedicoUpdateDTO medico)
        {
            try
            {
                var buscaMedico = await _medicoRepository.GetById(id);
                if (buscaMedico == null) throw new Exception("Médico para atualizar não encontrado.");

                _mapper.Map(medico, buscaMedico);

                await _medicoRepository.UpdateAsync(buscaMedico);

                return _mapper.Map<MedicoUpdateDTO>(buscaMedico);
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
