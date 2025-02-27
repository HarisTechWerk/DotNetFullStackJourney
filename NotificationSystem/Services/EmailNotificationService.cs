using NotificationSystem.Core;
using System.Net.Mail;

namespace NotificationSystem.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly SmtpClient _smtpClient;

        public EmailNotificationService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient ?? throw new ArgumentNullException(nameof(smtpClient));

        }

        public async Task SendNotificationAsync(string recepient, string message)
        {
            if (string.IsNullOrWhiteSpace(recepient))
                throw new ArgumentException("Recipient required", nameof(recepient));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message required", nameof(message));

            var mailMessage = new MailMessage("no-reply@company.com", recepient, "Notification", message);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }

}
    
