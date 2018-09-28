using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Following()
        {
            var following = _unitOfWork.Followings.GetFollowees(User.Identity.GetUserId());

            return View(following);
        }
    }
}