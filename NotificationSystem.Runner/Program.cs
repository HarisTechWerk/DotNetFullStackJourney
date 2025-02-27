using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NotificationSystem.Core;
using NotificationSystem.Services;
using System.Net;
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
            services.AddScoped<ITextTransformer, UpperCaseTransformer>();
            services.AddScoped<INotificationService, EmailNotificationService>(sp =>
                new EmailNotificationService(null, sp.GetRequiredService<ILogger<BaseNotificationService>>(),
                    sp.GetRequiredService<ITextTransformer>()));
            services.AddScoped<INotificationService, SMSNotificationService>(sp =>
                new SMSNotificationService(sp.GetRequiredService<ILogger<BaseNotificationService>>(),
                    new ReverseTextTransformer()));
            services.AddScoped<INotificationService, PushNotificationService>(sp =>
                new PushNotificationService(sp.GetRequiredService<ILogger<BaseNotificationService>>(),
                    sp.GetRequiredService<ITextTransformer>()));

            var provider = services.BuildServiceProvider();
            var notifications = provider.GetServices<INotificationService>();

            foreach (var service in notifications)
            {
                await service.SendNotificationAsync("user@domain.com", "Hello from " + service.GetType().Name);
            }
        }
    }
}
