using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOAN_CHuyenNGanh.Controllers
{
    public class UserInfoController : ApiController
    {
        private ApplicationDbContext _dbContext = null;
        public UserInfoController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult GetInfo()
        {
            var user = User.Identity.GetUserId();
            if (User.IsInRole("Teacher"))
            {
                return Ok(_dbContext.Teachers.Where(a => a.ApplicationUser.Id == user).Single());
            }
            return BadRequest();
        }
        [Route("api/UserInfo/{id}/{roleid}")]
        [HttpGet]
        public IHttpActionResult GetInfoApp(string id, string roleid)
        {
           
            if (roleid=="2")
            {
                return Ok(_dbContext.Teachers.Where(a => a.ApplicationUser.Id == id).Single());
            }
            return BadRequest();
        }
    }
}
