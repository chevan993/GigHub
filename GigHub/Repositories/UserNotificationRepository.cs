using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private ApplicationDbContext _context;

        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetUserNotificationFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}