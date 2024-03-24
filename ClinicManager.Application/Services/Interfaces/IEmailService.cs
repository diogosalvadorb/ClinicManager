namespace ClinicManager.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(Guid idAtendimento);
    }
}
