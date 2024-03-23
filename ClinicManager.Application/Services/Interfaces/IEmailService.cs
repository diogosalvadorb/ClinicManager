namespace ClinicManager.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(string email);
    }
}
