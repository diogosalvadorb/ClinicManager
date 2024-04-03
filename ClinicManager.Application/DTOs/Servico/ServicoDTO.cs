namespace ClinicManager.Application.DTOs.Servico
{
    public class ServicoDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Duracao { get; set; }
    }
}
