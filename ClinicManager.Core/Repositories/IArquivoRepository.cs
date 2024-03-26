using ClinicManager.Core.Entities;

namespace ClinicManager.Core.Repositories
{
    public interface IArquivoRepository
    {
        Task<Arquivo> AddAsync(Arquivo arquivo);
        Task<Arquivo> GetById(Guid id);
        Task UpdateAsync(Arquivo arquivo);
        Task RemoverAsync(Guid id);
    }
}
