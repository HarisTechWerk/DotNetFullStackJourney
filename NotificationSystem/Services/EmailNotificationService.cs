using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NotificationSystem.Core;
using System.Net.Mail;

namespace NotificationSystem.Services
{
    public class EmailNotificationService : BaseNotificationService
    {
        private readonly SmtpClient _smtpClient;

        public EmailNotificationService(SmtpClient smtpClient, ILogger<BaseNotificationService> logger)
            : base(logger)
        {
            _smtpClient = smtpClient;
        }

        protected override async Task SendNotificationInternalAsync(string recipient, string message)
        {
            if (_smtpClient == null)
            {
                await Task.Delay(100); // Simulate 100ms delay, email
                _logger.LogInformation($"Email sent to {0} (simulated)", recipient);
                return;
            }

            var mailMessage = new MailMessage("no-reply@company.com", recipient, "Notification", message);
            await _smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation($"Email sent to {0}", recipient);
        }
    }
}
