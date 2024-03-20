using AutoMapper;
using ClinicManager.Application.DTOs;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;
        public PacienteService(IPacienteRepository pacienteRepository,
                               IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDTO>> GetAll()
        {
            try
            {
                var pacientes = await _pacienteRepository.GetAll();
                if (pacientes == null) return null;

                var resultado = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PacienteDTO> GetById(Guid id)
        {
            try
            {
                var paciente = await _pacienteRepository.GetById(id);
                if (paciente == null) return null;

                var resultado = _mapper.Map<PacienteDTO>(paciente);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PacienteDTO> GetByCPF(string cpf)
        {
            try
            {
                var paciente = await _pacienteRepository.GetByCPF(cpf);
                if (paciente == null) return null;

                var resultado = _mapper.Map<PacienteDTO>(paciente);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PacienteDTO> GetByTelefone(string telefone)
        {
            try
            {
                var paciente = await _pacienteRepository.GetByTelefone(telefone);
                if (paciente == null) return null;

                var resultado = _mapper.Map<PacienteDTO>(paciente);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PacienteDTO> AddAsync(PacienteDTO paciente)
        {
            try
            {
                var adicionarPaciente = _mapper.Map<Paciente>(paciente);
                var adicionarPacienteDTO = await _pacienteRepository.AddAsync(adicionarPaciente);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PacienteUpdateDTO> UpdateAsync(Guid id, PacienteUpdateDTO paciente)
        {
            try
            {
                var buscaPaciente = await _pacienteRepository.GetById(id);
                if (buscaPaciente == null) throw new Exception("Paciente para atualizar não encontrado.");

                _mapper.Map(paciente, buscaPaciente);

                await _pacienteRepository.UpdateAsync(buscaPaciente);

                return _mapper.Map<PacienteUpdateDTO>(buscaPaciente);
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
                var buscaPaciente = _pacienteRepository.GetById(id);
                if(buscaPaciente == null) throw new Exception("Paciente para remover não encontrado.");

                await _pacienteRepository.RemoverAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
