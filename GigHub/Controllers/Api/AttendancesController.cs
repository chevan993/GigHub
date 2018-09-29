using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    public class AttendancesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(dto.GigId, userId);
            if (attendance != null)
            {
                return BadRequest("Attendance already exists!");
            }

            attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult RemoveAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(id, userId);

            if(attendance == null) { return NotFound(); }

            _unitOfWork.Attendances.Remove(attendance);
            _unitOfWork.Complete();

            return Ok(id);

            
        }

    }
}
