using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Core
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string recepient, string message);
    }
}
