using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NotificationSystem.Core;
using NotificationSystem.Services;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificationSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogging(logging => logging.AddConsole());
            services.AddScoped<INotificationService, EmailNotificationService>(_ =>
                new EmailNotificationService(new SmtpClient("smtp.company.com")));
            services.AddScoped<INotificationService, SMSNotificationService>();
            services.AddScoped<INotificationService, PushNotificationService>();

            var provider = services.BuildServiceProvider();
            var notifications = provider.GetServices<INotificationService>();


            foreach (var service in notifications)
            {
                await service.SendNotificationAsync("user@domain.com", "Hello from " + service.GetType().Name);
            }
        }
    }
}
