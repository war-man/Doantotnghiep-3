using DOAN_CHuyenNGanh.Models;
using DOAN_CHuyenNGanh.Models.DTOs;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DOAN_CHuyenNGanh.Controllers.API
{
    public class DeleteactionController : ApiController
    {
        private ApplicationDbContext _dbContext = null;
        public DeleteactionController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult RoleAction(RoleActionDto roleActionDto)
        {
            string[] temp = roleActionDto.RoleAction.Split(' ');
            var actionid = temp[1];
            var roleid = temp[0];
            if(!_dbContext.RoleActions.Any(a=>a.ActionId== actionid && a.RoleId == roleid))
            {
                return BadRequest("Không có action");
            }
            var roleaction = new RoleAction
            {
                ActionId= actionid,
                RoleId= roleid
            };
            _dbContext.RoleActions.Attach(roleaction);
            _dbContext.Entry(roleaction).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
