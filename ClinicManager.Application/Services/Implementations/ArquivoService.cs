using AutoMapper;
using ClinicManager.Application.DTOs.Arquivo;
using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Repositories;
using Microsoft.AspNetCore.Http;

namespace ClinicManager.Application.Services.Implementations
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IMapper _mapper;
        public ArquivoService(IArquivoRepository arquivoRepository,
                              IMapper mapper)
        {
            _arquivoRepository = arquivoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArquivoDTO>> UploadArquivo(ICollection<IFormFile> files)
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

                var arquivosDTO = _mapper.Map<IEnumerable<ArquivoDTO>>(arquivos);

                return arquivosDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ArquivoDTO> DownloadArquivo(Guid id)
        {
            try
            {
                var arquivo = await _arquivoRepository.GetById(id);

                var resultado = _mapper.Map<ArquivoDTO>(arquivo);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ArquivoUpdateDTO> UpdateAsync(Guid id, ArquivoUpdateDTO arquivo)
        {
            try
            {
                var buscaArquivo = await _arquivoRepository.GetById(id);
                if(buscaArquivo == null) throw new Exception("Arquivo para atualizar não encontrado.");

                _mapper.Map(arquivo, buscaArquivo);

                await _arquivoRepository.UpdateAsync(buscaArquivo);

                return _mapper.Map<ArquivoUpdateDTO>(buscaArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                var arquivo = await _arquivoRepository.GetById(id);
                if (arquivo == null) throw new Exception("Arquivo para remover não encontrado.");

                await _arquivoRepository.RemoveAsync(arquivo.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
