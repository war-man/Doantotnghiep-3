using DOAN_CHuyenNGanh.Models.DTOs;
using IdentitySample.Models;
using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOAN_CHuyenNGanh.Controllers
{
    public class CommonApiController : ApiController
    {
        private ApplicationDbContext _dbContext = null;
        public CommonApiController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult GetClass()
        {
            return Ok(_dbContext.Classes.ToList());
        }
        [Route("api/CommonApi/GetAllSchedule")]
        [HttpPost]
        public IHttpActionResult GetAllSchedule(ScheduleDTO scheduleDTO)
        {
            var scheduleTeachers = _dbContext.ScheduleTeacher.Where(a => a.TeacherId == scheduleDTO.idTeacher && a.SemesterId == scheduleDTO.Semester && a.YearId == scheduleDTO.Year).ToList();
            if (scheduleTeachers.Count == 0)
            {
                return BadRequest();
            }
            return Ok(scheduleTeachers);
        }
        [Route("api/CommonApi/GetSchedule")]
        [HttpPost]
        public IHttpActionResult GetSchedule(ScheduleDTO scheduleDTO)
        {
            var scheduleTeachers = _dbContext.ScheduleTeacher.Where(a => a.TeacherId == scheduleDTO.idTeacher && a.weekdays == scheduleDTO.dayweeks && a.SemesterId == scheduleDTO.Semester && a.YearId == scheduleDTO.Year).ToList();
            if(scheduleTeachers.Count==0)
            {
                ScheduleTeacher scheduleTeacher = new ScheduleTeacher();
                scheduleTeacher.SemesterId = scheduleDTO.Semester;
                scheduleTeacher.YearId = scheduleDTO.Year;
                scheduleTeacher.TeacherId = scheduleDTO.idTeacher;
                scheduleTeacher.weekdays = scheduleDTO.dayweeks;
                for (int i=1;i<=12;i++)
                {
                    scheduleTeacher.Lesson = i;
                    _dbContext.ScheduleTeacher.Add(scheduleTeacher);
                    _dbContext.SaveChanges();
                }
                return Ok(scheduleTeachers);
            }
            return Ok(scheduleTeachers);
        }
        [Route("api/CommonApi/SaveClassSchedule")]
        [HttpPost]
        public IHttpActionResult SaveClassSchedule(ScheduleDTO scheduleDTO)
        {
            var scheduleTeachers = _dbContext.ScheduleTeacher.SingleOrDefault(a => a.TeacherId == scheduleDTO.idTeacher && a.weekdays == scheduleDTO.dayweeks && a.SemesterId == scheduleDTO.Semester && a.YearId == scheduleDTO.Year&& a.Lesson==scheduleDTO.datasession);
            if (scheduleTeachers == null)
            {
                return BadRequest();
            }
            scheduleTeachers.ClassId = scheduleDTO.classid;

            return Ok();
        }
        [Route("api/CommonApi/Announce")]
        [HttpGet]
        public IHttpActionResult AnnounceToParent()
        {
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "45483600",
                ApiSecret = "zNy9sPaNEM7nb8y9"
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "HCM-EDU",
                to = "84919333309",
                text = "Moi phu huynh em XXX hop phu huynh vao luc yyy tai dia diem truong xxx phong aaa. Thong bao ve ket qua hoc ki 1 nam hoc 2017 2018"
            });
            return Ok(results);
        }
    }
}
