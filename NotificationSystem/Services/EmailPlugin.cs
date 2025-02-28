using NotificationSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Services
{
    public class EmailPlugin : IPlugin
    {
        public string Name => "EmailPlugin";

        public async Task ExecuteAsync(string recipient, string message)
        {
            // Simulate email plugin behavior
            await Task.Delay(100);
            Console.WriteLine($"Plugin {Name} sending to {recipient}: {message}");
        }
    }
}
