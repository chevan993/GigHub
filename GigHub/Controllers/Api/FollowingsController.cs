using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(userId, dto.FolloweeId);
            if (following != null)
                return BadRequest("Following already exists.");

            following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string Id)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(userId, Id);

            if(following == null) { return NotFound(); }

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(Id);
        }
    }
}
