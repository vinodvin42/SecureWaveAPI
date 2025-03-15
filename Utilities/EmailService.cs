using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SecureWaveAPI.Services.Interfaces;

namespace SecureWaveAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public EmailService(string smtpHost, int smtpPort, string fromEmail, string smtpUser, string smtpPass)
        {
            _fromEmail = fromEmail;
            _smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var mailMessage = new MailMessage(_fromEmail, toEmail, subject, message);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
