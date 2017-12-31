using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IdentitySample.Controllers
{
    public class TestController : ApiController
    {
        private ApplicationSignInManager _signInManager;

        public TestController(ApplicationSignInManager signInManager)
        {
            SignInManager = signInManager;
        }
        public new HttpContextBase HttpContext
        {
            get
            {
                HttpContextWrapper context =
                    new HttpContextWrapper(System.Web.HttpContext.Current);
                return (HttpContextBase)context;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
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

        private ApplicationDbContext _dbContext = null;
        public TestController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> postAsync([FromBody]LoginViewModel model)
        {
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
            
                var user = await _dbContext.Users.Include(a=>a.Roles).FirstOrDefaultAsync(e => e.Email == model.Email);
                
                return Ok(user);

            }
            else { return BadRequest(); }
        }
    }
}
