using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using GigHub.Persistence;
using System.Security.Principal;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GenericPrincipal User { get; set; }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig.IsCanceled || gig == null) { return NotFound(); }

            if(gig.ArtistId != User.Identity.GetUserId()) { return Unauthorized(); }

            gig.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
