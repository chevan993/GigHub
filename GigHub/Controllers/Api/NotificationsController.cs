using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebGrease.Css.Extensions;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var notifications = _unitOfWork.Notifications
                .GetUnreadNotificationsFor(User.Identity.GetUserId());

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _unitOfWork.UserNotifications
                .GetUserNotificationFor(User.Identity.GetUserId());

            notifications.ForEach(n => n.Read());

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
