using NotificationSystem.Core;

namespace NotificationSystem.Services
{
    public class PushNotificationService : INotificationService
    {
        public async Task SendNotificationAsync(string recepient, string message)
        {
            if (string.IsNullOrWhiteSpace(recepient))
                throw new ArgumentException("Recipient required", nameof(recepient));
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message required", nameof(message));

            // Simulate push notification (Firebase, OneSignal, etc. in production)
            await Task.Delay(1000); // Simulate 1 second delay
            Console.WriteLine($"Push notification to {recepient}: {message}");
        }
    }
}
