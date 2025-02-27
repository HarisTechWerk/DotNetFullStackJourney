using NotificationSystem.Core;

namespace NotificationSystem.Services
{
    public class SMSNotificationService : INotificationService
    {
        public async Task SendNotificationAsync(string recepient, string message)
        {
            if (string.IsNullOrWhiteSpace(recepient))
                throw new ArgumentException("Recipient required", nameof(recepient));
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message required", nameof(message));

            // Simulate SMS (Twilio, Nexmo, etc. in production)
            await Task.Delay(1000); // Simulate 1 second delay
            Console.WriteLine($"SMS to {recepient}: {message}");
        }
    }
}
