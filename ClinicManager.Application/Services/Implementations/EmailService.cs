using ClinicManager.Application.Services.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ClinicManager.Application.Services.Implementations
{
    public class EmailService : IEmailService
    {
        public void EnviarEmailAsync(string email)
        {
            MailMessage mailMessage = new MailMessage("diogosbarbosa93@gmail.com", email);

            mailMessage.Subject = "Assunto E-Mail";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = "<p> Exemplo Texto Email, Teste acentuação número</p>";
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("diogosbarbosa93@gmail.com", "");

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
 
        }
    }
}
