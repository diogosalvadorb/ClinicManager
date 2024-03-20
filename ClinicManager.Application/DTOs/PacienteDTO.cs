namespace ClinicManager.Application.DTOs
{
    public class PacienteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string SobreNome { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string TipoSanguineo { get; set; } = string.Empty;
        public double Altura { get; set; }
        public double Peso { get; set; }
        public string Endereco { get; set; } = string.Empty;
    }
}
