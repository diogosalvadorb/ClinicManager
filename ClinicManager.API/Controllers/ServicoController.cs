using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        public ServicoController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var servicos = await _servicoService.GetAll();
                return Ok(servicos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Serviços. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var servico = await _servicoService.GetById(id);
                if (servico == null) return NotFound();

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Servico. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Servico servico)
        {
            try
            {
                if (servico == null)
                {
                    return BadRequest();
                }

                var idNovoServico = _servicoService.AddAsync(servico);

                return CreatedAtAction(nameof(GetById), new { id = idNovoServico }, servico);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Serviço. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Servico servico)
        {
            try
            {
                if (servico == null || servico.Id != id)
                {
                    return BadRequest();
                }

                await _servicoService.UpdateAsync(servico);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Serviço. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _servicoService.RemoverAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover Serviço. Erro: {ex.Message}");
            }
        }
    }
}
