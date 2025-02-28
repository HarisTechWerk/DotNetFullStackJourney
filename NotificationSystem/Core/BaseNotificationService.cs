using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace NotificationSystem.Core;


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
        string timestamp = DateTime.Now.ToStandardDateString();
        _logger.LogInformation($"Sending notification to {0} at {1} via {2}", recepient, timestamp, GetType().Name);
        await SendNotificationInternalAsync(recepient, message);
    }

    protected abstract Task SendNotificationInternalAsync(string recepient, string message);
}
