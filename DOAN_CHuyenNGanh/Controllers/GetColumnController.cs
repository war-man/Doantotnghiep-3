using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOAN_CHuyenNGanh.Controllers
{
    public class GetColumnController : ApiController
    {
        private ApplicationDbContext _dbContext { get; set; }
        public GetColumnController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            //var res = _dbContext.SetColumnContact.Where(a =>  a.YearId == year).Single();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Index([FromBody]SetColumnContact value)
        {
            var userid = User.Identity.GetUserId();
            var teacher = _dbContext.Teachers.Where(a => a.ApplicationUser.Id == value.TeacherId).Single();
            var res = _dbContext.SetColumnContact.Where(a => a.TeacherId == teacher.Id && a.YearId == value.YearId).Single();
            return Ok(res);
        }


    }
}
