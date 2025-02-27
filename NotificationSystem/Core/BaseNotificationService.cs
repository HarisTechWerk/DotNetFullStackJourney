using Microsoft.Extensions.Logging;

namespace NotificationSystem.Core
    
{
    public abstract class BaseNotificationService : INotificationService
    {
        protected readonly ILogger<BaseNotificationService> _logger;
        protected readonly ITextTransformer _textTransformer;

        protected BaseNotificationService(ILogger<BaseNotificationService> logger, ITextTransformer textTransformer)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _textTransformer = textTransformer ?? throw new ArgumentNullException(nameof(textTransformer));
        }

        public async Task SendNotificationAsync(string recepient, string message)
        {
            if (string.IsNullOrWhiteSpace(recepient))
                throw new ArgumentException("Recipient required", nameof(recepient));
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message required", nameof(message));

             string transformedMessage = _textTransformer.TransformText(message);
            _logger.LogInformation($"Sending notification to {0} via {1}", recepient, GetType().Name);
            await SendNotificationInternalAsync(recepient, message);
        }

        protected abstract Task SendNotificationInternalAsync(string recepient, string message);
    }
}
