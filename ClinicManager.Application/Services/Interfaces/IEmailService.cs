namespace ClinicManager.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(Guid idAtendimento);
    }
}
