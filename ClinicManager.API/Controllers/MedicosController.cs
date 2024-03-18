using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var medicos = await _medicoService.GetAll();
                return Ok(medicos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar buscar Médicos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var medico = await _medicoService.GetById(id);
                if (medico == null) return NotFound();

                return Ok(medico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Médicos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Medico medico)
        {
            try
            {
                if (medico == null)
                {
                    return BadRequest();
                }

                var idNovoMedico = _medicoService.AddAsync(medico);

                return CreatedAtAction(nameof(GetById), new { id = idNovoMedico }, medico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Médico. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Medico medico)
        {
            try
            {
                if (medico == null || medico.Id != id)
                {
                    return BadRequest();
                }

                await _medicoService.UpdateAsync(medico);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Médicos. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _medicoService.RemoverAsync(id);

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
