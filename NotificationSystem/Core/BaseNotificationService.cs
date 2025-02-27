using Microsoft.Extensions.Logging;

namespace NotificationSystem.Core
    
{
    public abstract class BaseNotificationService : INotificationService
    {
        protected readonly ILogger<BaseNotificationService> _logger;

        protected BaseNotificationService(ILogger<BaseNotificationService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SendNotificationAsync(string recepient, string message)
        {
            if (string.IsNullOrWhiteSpace(recepient))
                throw new ArgumentException("Recipient required", nameof(recepient));
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message required", nameof(message));

            _logger.LogInformation($"Sending notification to {0} via {1}", recepient, GetType().Name);
        }

        protected abstract Task SendNotificationInternalAsync(string recepient, string message);
    }
}
