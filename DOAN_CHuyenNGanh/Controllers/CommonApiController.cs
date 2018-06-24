using DOAN_CHuyenNGanh.Models.DTOs;
using IdentitySample.Models;
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
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
