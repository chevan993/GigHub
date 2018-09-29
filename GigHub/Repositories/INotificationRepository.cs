using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetUnreadNotificationsFor(string userId);
    }
}
