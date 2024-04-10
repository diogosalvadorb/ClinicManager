namespace ClinicManager.Application.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public string Perfil { get; set; } = string.Empty;
        public Guid IdPaciente { get; set; }
        public Guid IdMedico { get; set; }
    }
}
