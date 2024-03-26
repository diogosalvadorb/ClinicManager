using ClinicManager.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IArquivoService
    {
        Task<IEnumerable<ArquivoDTO>> UploadArquivo(ICollection<IFormFile> files);
        Task<ArquivoDTO> DownloadArquivo(Guid id);
        Task<ArquivoUpdateDTO> UpdateAsync(Guid id, ArquivoUpdateDTO arquivo);
        Task RemoveAsync(Guid id);
    }
}
