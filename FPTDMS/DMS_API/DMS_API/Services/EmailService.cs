using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DMS_API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_configuration["Smtp:Host"]))
                {
                    smtpClient.Port = int.Parse(_configuration["Smtp:Port"]);
                    smtpClient.UseDefaultCredentials = false; // Add this line
                    smtpClient.Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]);
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(_configuration["Smtp:From"]);
                        mailMessage.To.Add(toEmail);
                        mailMessage.Subject = subject;
                        mailMessage.Body = message;
                        mailMessage.IsBodyHtml = true;

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                _logger.LogInformation("Email sent successfully to {Email}", toEmail);
            }
            catch (SmtpException ex)
            {
                _logger.LogError(ex, "SMTP Exception: Failure sending email to {Email}", toEmail);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception: Failure sending email to {Email}", toEmail);
                throw;
            }
        }

    }
}
