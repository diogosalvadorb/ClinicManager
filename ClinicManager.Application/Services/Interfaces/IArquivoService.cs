using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Application.Services.Interfaces
{
    public interface IArquivoService
    {
        Task<IEnumerable<Arquivo>> UploadArquivo(ICollection<IFormFile> files);
        Task<Arquivo> DownloadArquivo(Guid id);
    }
}
