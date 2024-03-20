namespace ClinicManager.Application.DTOs
{
    public class ServicoDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Duracao { get; set; }
    }
}
