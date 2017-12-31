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


        // GET: CreateStudent
        //[Authorize(Roles = "Admin")]
      
        public ActionResult Index()
        {
            var list_Class = _dbContext.Classes.ToList();
            var model = new StudentViewModel
            {
                Class = list_Class,
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                var user_parent = new ApplicationUser { UserName = model.Email_parent, Email = model.Email_parent };
                var result_parent = await UserManager.CreateAsync(user_parent, model.Password_parent);
                var addroles_student = await UserManager.AddToRolesAsync(user.Id, "Student");
                var addroles_parent = await UserManager.AddToRolesAsync(user_parent.Id, "Parent");
                if (result.Succeeded && result_parent.Succeeded&& addroles_student.Succeeded&& addroles_parent.Succeeded)
                {
                    //var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                    //ViewBag.Link = callbackUrl;
                    

                    return View();
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
    
}