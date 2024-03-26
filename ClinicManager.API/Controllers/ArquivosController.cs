﻿using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivosController : ControllerBase
    {
        private readonly IArquivoService _arquivoService;
        public ArquivosController(IArquivoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        [HttpPost("upload")]
        public async Task<ActionResult<Arquivo>> UploadArquivoAsync([FromForm] ICollection<IFormFile> files)
        {
            try
            {
                var arquivoId = await _arquivoService.UploadArquivo(files);
                return Ok(arquivoId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro durante o upload do arquivo: {ex.Message}");
            }
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadArquivoAsync(Guid id)
        {
            try
            {
                var arquivo = await _arquivoService.DownloadArquivo(id);

                if (arquivo == null)
                    return NotFound();

                return File(arquivo.Data, arquivo.TipoConteudo, arquivo.NomeArquivo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro durante o download do arquivo: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _arquivoService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar remover Arquivo. Erro: {ex.Message}");
            }
        }
    }
}
