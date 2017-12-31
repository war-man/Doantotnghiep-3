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
    }
}
