using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using Microsoft.AspNetCore.Http;

namespace ClinicManager.Application.Services.Implementations
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        public ArquivoService(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public async Task<IEnumerable<Arquivo>> UploadArquivo(ICollection<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                    throw new ArgumentException("Nenhum arquivo fornecido para upload.");

                var arquivos = new List<Arquivo>();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(stream);
                            var arquivo = new Arquivo { Id = Guid.NewGuid(), NomeArquivo = formFile.FileName, Data = stream.ToArray(), TipoConteudo = formFile.ContentType };

                            await _arquivoRepository.AddAsync(arquivo);
                            arquivos.Add(arquivo);
                        }
                    }
                }

                return arquivos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Arquivo> DownloadArquivo(Guid id)
        {
            try
            {
                var arquivo = await _arquivoRepository.GetById(id);

                return arquivo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  
    }
}
