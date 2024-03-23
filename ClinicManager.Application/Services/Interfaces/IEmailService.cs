namespace ClinicManager.Application.Services.Interfaces
{
    public interface IEmailService
    {
        void EnviarEmailAsync(string email);
    }
}
