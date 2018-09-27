using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetGigUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        Gig GetGigById(int gigId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        void Add(Gig gig);
    }
}
