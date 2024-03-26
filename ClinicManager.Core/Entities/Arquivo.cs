namespace ClinicManager.Core.Entities
{
    public class Arquivo : BaseEntity
    {
        public byte[] Data { get; set; }
        public string NomeArquivo { get; set; } = string.Empty;
        public string TipoConteudo { get; set; } = string.Empty;
    }
}