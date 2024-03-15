using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Task<IEnumerable<Paciente>> GetAll()
        {
            try
            {
                var pacientes = _pacienteRepository.GetAll();
                if (pacientes == null) return null;

                return pacientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Paciente> GetById(Guid id)
        {
            try
            {
                var paciente = _pacienteRepository.GetById(id);
                if (paciente == null) return null;

                return paciente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Paciente> GetByCPF(string cpf)
        {
            try
            {
                var paciente = _pacienteRepository.GetByCPF(cpf);
                if (paciente == null) return null;

                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Paciente> GetByTelefone(string telefone)
        {
            try
            {
                var paciente = _pacienteRepository.GetByTelefone(telefone);
                if (paciente == null) return null;

                return paciente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Paciente> AddAsync(Paciente paciente)
        {
            try
            {
                var adicionarPaciente = _pacienteRepository.AddAsync(paciente);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            try
            {
                var buscaPaciente = await _pacienteRepository.GetById(paciente.Id);
                if (buscaPaciente == null) throw new Exception("Paciente para atualizar não encontrado.");

                await _pacienteRepository.UpdateAsync(paciente);
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
