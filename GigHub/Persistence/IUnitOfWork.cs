using GigHub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Persistence
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IAttendanceRepository Attendances { get; }
        IGenreRepository Genres { get; }
        IFollowingRepository Followings { get; }
        INotificationRepository Notifications { get; }
        IUserNotificationRepository UserNotifications { get; }
        void Complete();
    }
}
