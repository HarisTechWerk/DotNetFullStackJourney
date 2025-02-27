using Microsoft.Extensions.Logging;
using NotificationSystem.Core;

namespace NotificationSystem.Services
{
    public class SMSNotificationService : BaseNotificationService
    {
        public SMSNotificationService(ILogger<BaseNotificationService> logger, ITextTransformer textTransformer)
            : base(logger, textTransformer)
        {
        }

        protected override async Task SendNotificationInternalAsync(string recipient, string message)
        {
            string transformedMessage = _textTransformer.TransformText(message); // Apply transform (reversed)

            await Task.Delay(100); // Simulate 100ms delay, SMS
            _logger.LogInformation("SMS sent to {Recipient}", transformedMessage);
        }
    }
}