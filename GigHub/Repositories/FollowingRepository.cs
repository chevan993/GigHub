using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Web;

namespace GigHub.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string artistId, string userId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }

        public IEnumerable<ApplicationUser> GetFollowees(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(a => a.Followee)
                .ToList();
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}