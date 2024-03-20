namespace ClinicManager.Application.DTOs
{
    public class MedicoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string SobreNome { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string TipoSanguineo { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Especialista { get; set; } = string.Empty;
        public string Registro { get; set; } = string.Empty;
    }
}
