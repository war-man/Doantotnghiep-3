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
        [HttpPost]
        public IHttpActionResult GetSchedule(ScheduleDTO scheduleDTO)
        {
            var scheduleTeachers = _dbContext.ScheduleTeacher.Where(a => a.Teacher.Id == scheduleDTO.idTeacher && a.weekdays == scheduleDTO.dayweeks && a.Semester.Id == scheduleDTO.Semester && a.Year.Id == scheduleDTO.Year).ToList();
            if(scheduleTeachers.Count()==0)
            {
                ScheduleTeacher scheduleTeacher = new ScheduleTeacher();
                scheduleTeacher.Semester.Id = scheduleDTO.Semester;
                scheduleTeacher.Year.Id = scheduleDTO.Semester;
                scheduleTeacher.Teacher.Id = scheduleDTO.idTeacher;
                for(int i=2;i<=12;i++)
                {
                    scheduleTeacher.Lesson = i;
                    _dbContext.ScheduleTeacher.Add(scheduleTeacher);
                    _dbContext.SaveChanges();
                }
                return Ok(scheduleTeachers);
            }
            return Ok(scheduleTeachers);
        }
    }
}
