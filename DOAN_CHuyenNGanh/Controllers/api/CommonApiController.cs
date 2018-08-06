using DOAN_CHuyenNGanh.Controllers.ViewModel;
using DOAN_CHuyenNGanh.Models;
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
            _dbContext.SaveChanges();
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
        [Route("api/CommonApi/GetMarkAllSubjectForStudent")]
        [HttpPost]
        public IHttpActionResult GetMarkAllSubjectForStudent(SubjectForStudentViewModel subjectForStudentViewModel)
        {
            var temp = _dbContext.Contacts.Include("Year").Include("Subject").Include("Class").Include("Semester").Where(a => a.SemesterId == subjectForStudentViewModel.SemesterId
                                                 && a.CLassId == subjectForStudentViewModel.ClassId
                                                 && a.YearId == subjectForStudentViewModel.YearId
                                                 && a.StudentId == subjectForStudentViewModel.StudentId).ToList();
            return Ok(temp);
        }
        [Route("api/CommonApi/GetMarkBySubjectForStudent")]
        [HttpPost]
        public IHttpActionResult GetMarkBySubjectForStudent(SubjectForStudentViewModel subjectForStudentViewModel)
        {
            var temp = _dbContext.Contacts.Include("Year").Include("Subject").Include("Class").Include("Semester").Where(a => a.SemesterId == subjectForStudentViewModel.SemesterId
                                                 && a.CLassId == subjectForStudentViewModel.ClassId
                                                 && a.YearId == subjectForStudentViewModel.YearId
                                                 && a.StudentId == subjectForStudentViewModel.StudentId
                                                 &&a.SubjectId==subjectForStudentViewModel.SubjectId).ToList();
            return Ok(temp);
        }
        [Route("api/CommonApi/GetListSemester")]
        [HttpGet]
        public IHttpActionResult GetListSemester()
        {
            
            return Ok(_dbContext.Semesters.ToList());
        }
        [Route("api/CommonApi/GetListYear")]
        [HttpGet]
        public IHttpActionResult GetListYear()
        {

            return Ok(_dbContext.Years.ToList());
        }
        [Route("api/CommonApi/GetListSubject")]
        [HttpGet]
        public IHttpActionResult GetListSubject()
        {

            return Ok(_dbContext.Subjects.ToList());
        }
        [Route("api/CommonApi/GetListClass")]
        [HttpGet]
        public IHttpActionResult GetListClass()
        {

            return Ok(_dbContext.Classes.ToList());
        }
        [Route("api/CommonApi/GetListClassById")]
        [HttpGet]
        public IHttpActionResult GetListClassById(string Id)
        {

            return Ok(_dbContext.Classes.Where(a=>a.Id.Contains(Id)).ToList());
        }
        [Route("api/CommonApi/GetListStudentSortClass")]
        [HttpPost]
        public IHttpActionResult GetListStudentSortClass(ExportStudentViewModel studentViewModel)
        {
            var listStudentHaveClass = _dbContext.ClassStudent.Where(a => a.YearId == studentViewModel.YearId).AsEnumerable();
            var student = _dbContext.Students.Where(a => listStudentHaveClass.Any(s => s.StudentId == a.Id)).AsEnumerable();
            var except =_dbContext.Students.Except(student);
            //var listStudent = _dbContext.Students.Where(i => !listStudentHaveClass.Any(a=>a.StudentId==i.Id)).AsQueryable();
            return Ok(except);
        }
        [Route("api/CommonApi/GetListStudentInClass")]
        [HttpPost]
        public IHttpActionResult GetListStudentInClass(ExportStudentViewModel studentViewModel)
        {
            var listStudentHaveClass = _dbContext.ClassStudent.Where(a => a.YearId == studentViewModel.YearId&&a.ClassId==studentViewModel.ClassId).AsEnumerable();
            var student = _dbContext.Students.Where(a => listStudentHaveClass.Any(s => s.StudentId == a.Id)).AsEnumerable();
            //var listStudent = _dbContext.Students.Where(i => !listStudentHaveClass.Any(a=>a.StudentId==i.Id)).AsQueryable();
            return Ok(student);
        }
        [Route("api/CommonApi/SaveListStudent")]
        [HttpPost]
        public IHttpActionResult SaveListStudent(IEnumerable<ClassStudent> listClassStudent)
        {
            var temp = listClassStudent.Select(a=> new ClassStudent { YearId= a.YearId,ClassId =a.ClassId}).First();
            _dbContext.ClassStudent.RemoveRange(_dbContext.ClassStudent.Where(a => a.YearId == temp.YearId && a.ClassId == temp.ClassId));
            _dbContext.SaveChanges();
            foreach (var item in listClassStudent)
            {
                var classStudent = _dbContext.ClassStudent.SingleOrDefault(a => a.StudentId == item.StudentId&&a.YearId==item.YearId&&a.ClassId==item.ClassId);
                if(classStudent==null)
                {
                    _dbContext.ClassStudent.Add(item);
                    _dbContext.SaveChanges();
                }
            }

            return Ok("Lưu lớp thành công");
        }
    } 
}
