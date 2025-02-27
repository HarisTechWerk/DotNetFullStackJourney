using Microsoft.Extensions.Logging;
using NotificationSystem.Core;

namespace NotificationSystem.Services
{
    public class PushNotificationService : BaseNotificationService
    {
        public PushNotificationService(ILogger<BaseNotificationService> logger, ITextTransformer textTransformer)
            : base(logger, textTransformer)
        {
        }

        protected override async Task SendNotificationInternalAsync(string recipient, string message)
        {
            await Task.Delay(100); // Simulate push
            _logger.LogInformation("Push sent to {Recipient}", recipient);
        }
    }
}