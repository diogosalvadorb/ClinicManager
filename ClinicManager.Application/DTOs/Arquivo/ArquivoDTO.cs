namespace ClinicManager.Application.DTOs.Arquivo
{
    public class ArquivoDTO
    {
        public byte[] Data { get; set; }
        public string NomeArquivo { get; set; } = string.Empty;
        public string TipoConteudo { get; set; } = string.Empty;
    }
}
