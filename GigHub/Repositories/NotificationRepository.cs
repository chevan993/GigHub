using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GigHub.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;    
        }

        public IEnumerable<Notification> GetUnreadNotificationsFor(string userId)
        {
            return _context.UserNotifications
            .Where(un => un.UserId == userId && !un.IsRead)
            .Select(un => un.Notification)
            .Include(n => n.Gig.Artist)
            .ToList();
        }
    }
}