using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOAN_CHuyenNGanh.Controllers
{

    public class ContactController : ApiController
    {
        private ApplicationDbContext _dbContext = null;
        public ContactController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Save([FromBody] Contact contact)
        {
            var checknull = _dbContext.Contacts.Where(a => a.CLassId == contact.CLassId && a.SemesterId == contact.SemesterId && a.StudentId == contact.StudentId && a.YearId == contact.YearId && a.SubjectId == contact.SubjectId).Single();
            if(checknull!=null)
            {
                var contacts = new Contact
                {
                    CLassId = contact.CLassId,
                    SemesterId = contact.SemesterId,
                    StudentId = contact.StudentId,
                    YearId = contact.YearId,
                    SubjectId = contact.SubjectId,                   
                    mark_5m1= contact.mark_5m1,
                    mark_5m2= contact.mark_5m2,
                    mark_5m3= contact.mark_5m3,
                    mark_5m4= contact.mark_5m4,
                    mark_5m5= contact.mark_5m5,
                    mark_15m1= contact.mark_15m1,
                    mark_15m2= contact.mark_15m2,
                    mark_15m3= contact.mark_15m3,
                    mark_15m4= contact.mark_15m4,
                    mark_15m5= contact.mark_15m5,
                    mark_45m1= contact.mark_45m1,
                    mark_45m2= contact.mark_45m2,
                    mark_45m3= contact.mark_45m3,
                    mark_45m4= contact.mark_45m4
                };
                _dbContext.Entry(checknull).CurrentValues.SetValues(contacts);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
