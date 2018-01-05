using DOAN_CHuyenNGanh.Models;
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
    public class GetListStudentController : ApiController
    {
        private ApplicationDbContext _dbContext = null;
        public GetListStudentController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult GetStudent([FromBody]FocusExams focusExams)
        {
            var listStudent = _dbContext.ClassStudent.Include("Student").Include("Class").Where(a => a.Class.name_Class.Contains(focusExams.Grade)).ToList();
            var listClass =_dbContext.Classes.Where(a => a.name_Class.Contains(focusExams.Grade)).ToList();
            var focusExamsDTO = new FocusExamsDTO
            {
                ClassStudent=listStudent,
                Class=listClass
            };
            return Ok(focusExamsDTO);
        }
        [Route("api/PostInfoExams")]
        [HttpPost]
        public IHttpActionResult PostInfoExams([FromBody]InfoExamsDto infoExamsDto)
        {
            if(!ModelState.IsValid)
            {
                DateTime datetime = infoExamsDto.GetDateTime();
                var temp = _dbContext.FocusExamses.Select(a => a.DateTime) ;
                
                if(!_dbContext.FocusExamses.Any(a=>a.SemesterId==infoExamsDto.SemesterId&&a.SemesterId==infoExamsDto.SemesterId&&a.YearId==infoExamsDto.YearId&&a.Grade==infoExamsDto.Grade&&a.SubjectId==infoExamsDto.SubjectId&&a.Mark==infoExamsDto.Mark))
                {
                    if (!_dbContext.FocusExamses.Any(a => a.DateTime.Hour == datetime.Hour && a.DateTime == datetime))
                    {
                        var Id = _dbContext.FocusExamses.Count() + 1;
                        FocusExams focusExams = new FocusExams
                        {
                            DateTime = infoExamsDto.GetDateTime(),
                            Grade = infoExamsDto.Grade,
                            Id = "KT" + Id,
                            Mark = infoExamsDto.Mark,
                            Name = infoExamsDto.Name,
                            SemesterId = infoExamsDto.SemesterId,
                            SubjectId = infoExamsDto.SubjectId,
                            YearId = infoExamsDto.YearId
                        };
                        _dbContext.FocusExamses.Add(focusExams);
                        _dbContext.SaveChanges();
                        return Ok();
                    }
                    return BadRequest("Trùng giờ thi với kỳ thi khác");
                }
                return BadRequest("Đã có kỳ thi này xin kiểm tra lại!");

            }
            return BadRequest(ModelState);
        }
    }
}
