using ClinicManager.Application.DTOs;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;
        private readonly IEmailService _emailService;
        public AtendimentoController(IAtendimentoService atendimentoService, IEmailService emailService)
        {
            _atendimentoService = atendimentoService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var atendimentos = await _atendimentoService.GetAll();
                return Ok(atendimentos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Atendimentos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var atendimento = await _atendimentoService.GetById(id);
                if (atendimento == null) return NotFound();

                return Ok(atendimento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Atendimento. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AtendimentoDTO atendimento)
        {
            try
            {
                if (atendimento == null)
                {
                    return BadRequest();
                }

                var idNovoAtendimento = _atendimentoService.AddAsync(atendimento);

                return CreatedAtAction(nameof(GetById), new { id = idNovoAtendimento }, atendimento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Atendimento. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] AtendimentoUpdateDTO atendimento)
        {
            try
            {
                if (atendimento == null)
                {
                    return BadRequest();
                }

                await _atendimentoService.UpdateAsync(id, atendimento);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Atendimento. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _atendimentoService.RemoverAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover Atendimento. Erro: {ex.Message}");
            }
        }
    }
}
