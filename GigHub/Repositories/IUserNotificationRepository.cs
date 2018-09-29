using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotificationFor(string userId);
    }
}