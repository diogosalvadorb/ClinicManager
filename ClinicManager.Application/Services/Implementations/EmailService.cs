using ClinicManager.Application.Services.Interfaces;
using ClinicManager.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ClinicManager.Application.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly int _port;
        private readonly string _host;
        private readonly string _emailSender;
        private readonly string _password;
        public EmailService(IConfiguration configuration,
                            IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
            _port = Convert.ToInt32(configuration["EmailConfiguration:Port"]);
            _host = configuration["EmailConfiguration:Host"];
            _emailSender = configuration["EmailConfiguration:From"];
            _password = configuration["EmailConfiguration:Password"];
        }

        public async Task EnviarEmailAsync(Guid idAtendimento)
        {
            try
            {
                string emailPaciente = _pacienteRepository.GetEmail(idAtendimento).Result;

                MailMessage mailMessage = new MailMessage(_emailSender, emailPaciente);

                mailMessage.Subject = "Confirmação de Agendamento";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "<p> Exemplo Texto Email, Teste acentuação número</p>";
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.SubjectEncoding = Encoding.UTF8;

                SmtpClient smtpClient = new SmtpClient(_host, _port);

                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailSender, _password);

                smtpClient.EnableSsl = true;

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
