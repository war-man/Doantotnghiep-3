using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security;

namespace IdentitySample.Controllers
{
    public class TestController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public TestController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat, ApplicationSignInManager signInManger)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
            SignInManager = signInManger;

        }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? Request.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        private ApplicationDbContext _dbContext = null;
        public TestController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [System.Web.Http.HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> postAsync([FromBody]LoginViewModel model)
        {
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
               
                var user = await _dbContext.Users.Include(a=>a.Roles).FirstOrDefaultAsync(e => e.UserName == model.Email);
               
                if (User.IsInRole("Teacher"))
                {
                   var resultTeacher = await _dbContext.Teachers.FirstOrDefaultAsync(e => e.ApplicationUser.Id == user.Id);
                    return Ok(resultTeacher);
                }

                return Ok(user);
                

            }
            else { return BadRequest(); }
        }
    }
   
}
