using Microsoft.Extensions.Logging;
using NotificationSystem.Core;
using System.Net.Mail;

namespace NotificationSystem.Services
{
    public class EmailNotificationService : BaseNotificationService
    {
        private readonly SmtpClient _smtpClient;

        public EmailNotificationService(SmtpClient smtpClient, ILogger<BaseNotificationService> logger, ITextTransformer textTransformer)
            : base(logger, textTransformer)
        {
            _smtpClient = smtpClient;
        }

        protected override async Task SendNotificationInternalAsync(string recipient, string message)
        {
            string transformedMessage = _textTransformer.TransformText(message); // Apply transform (uppercase)

            if (_smtpClient == null)
            {
                await Task.Delay(100); // Simulate 100ms delay, email
                _logger.LogInformation("Email sent to {Recipient} (simulated)", recipient);
                return;
            }

            var mailMessage = new MailMessage("no-reply@company.com", recipient, "Notification", transformedMessage);
            await _smtpClient.SendMailAsync(mailMessage);
            _logger.LogInformation("Email sent to {Recipient}", recipient);
        }
    }
}