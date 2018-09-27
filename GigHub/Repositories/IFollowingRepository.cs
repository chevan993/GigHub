using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string artistId, string userId);
    }
}
