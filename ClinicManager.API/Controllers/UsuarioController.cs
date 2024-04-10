using ClinicManager.Application.DTOs.Usuario;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _userService;
        private readonly IAuthService _authService;
        public UsuarioController(IUsuarioService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var usuario = await _userService.GetById(id);
                if (usuario == null) return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar Usuário. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }

                var idNovoUsuario = await _userService.AddAsync(usuario);

                return CreatedAtAction(nameof(GetById), new { id = idNovoUsuario }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO usuariomodel)
        {
            try
            {
                var usuario = await _userService.GetUsuarioByLoginAndSenhaAsync(usuariomodel.Login, usuariomodel.Senha);
                if (usuario == null) return Unauthorized("Usuário ou Senha está errado");

                return Ok(new 
                { 
                    Login = usuario.Login,
                    Token = _authService.GenerateJwtToken(usuario.Login, usuario.Perfil)
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar Login. Erro: {ex.Message}");
            }
        }
    }
}
