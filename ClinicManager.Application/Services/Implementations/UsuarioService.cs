using AutoMapper;
using ClinicManager.Application.DTOs.Atendimento;
using ClinicManager.Application.DTOs.Usuario;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using ClinicManager.Infrastructure.Persistence;
using ClinicManager.Infrastructure.Persistence.Repositories;

namespace ClinicManager.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository; 
        private readonly IMapper _mapper;
        public UsuarioService(IAuthService authService, IUsuarioRepository usuarioRepository, ClinicManagerDbContext context, IMapper mapper)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> AddAsync(UsuarioDTO usuario)
        {
            try
            {
                var hashSenha = _authService.ComputeSha256Hash(usuario.Senha);

                var adicionarUsuario = _mapper.Map<Usuario>(usuario);

                adicionarUsuario.Senha = hashSenha;

                var adicionarUsuarioEntiadde = await _usuarioRepository.AddAsync(adicionarUsuario);

                var retornoUsuarioDTO = _mapper.Map<UsuarioDTO>(adicionarUsuario);

                return retornoUsuarioDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> GetById(Guid id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetById(id);
                if (usuario == null) return new UsuarioDTO();

                var resultado = _mapper.Map<UsuarioDTO>(usuario);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDTO> GetUsuarioByLoginAndSenhaAsync(string login, string senha)
        {
            try
            {
                var hashSenha = _authService.ComputeSha256Hash(senha);

                var usuario = await _usuarioRepository.GetUsuarioByLoginAndSenhaAsync(login, hashSenha);
                if (usuario == null) return null;

                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

                return usuarioDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

