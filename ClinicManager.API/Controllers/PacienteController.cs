using ClinicManager.Application.DTOs.Paciente;
using ClinicManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var pacientes = await _pacienteService.GetAll();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Pacientes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var paciente = await _pacienteService.GetById(id);
                if (paciente == null) return NotFound();

                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Paciente. Erro: {ex.Message}");
            }
        }

        [HttpGet("telefone/{telefone}")]
        public async Task<IActionResult> GetByTelefone(string telefone)
        {
            try
            {
                var paciente = await _pacienteService.GetByTelefone(telefone);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Paciente. Erro: {ex.Message}");
            }
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            try
            {
                var paciente = await _pacienteService.GetByCPF(cpf);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Paciente. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PacienteDTO paciente)
        {
            try
            {
                if (paciente == null)
                {
                    return BadRequest();
                }

                var idNovoPaciente = await _pacienteService.AddAsync(paciente);

                return CreatedAtAction(nameof(GetById), new { id = idNovoPaciente }, paciente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Paciente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PacienteUpdateDTO paciente)
        {
            try
            {
                if (paciente == null)
                {
                    return BadRequest();
                }

                await _pacienteService.UpdateAsync(id, paciente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Médicos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                await _pacienteService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover Médico. Erro: {ex.Message}");
            }
        }
    }
}
