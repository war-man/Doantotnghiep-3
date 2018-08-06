using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CHuyenNGanh.Controllers
{
    [DynamicRoleAuthorize]
    public class CreateStudentController : Controller
    {
        private ApplicationDbContext _dbContext = null;
        public CreateStudentController()
        {
            _dbContext = new ApplicationDbContext();
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


    }
    
}