namespace ClinicManager.Core.Entities
{
    public class Servico : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int Duracao { get; set; }
    }
}
