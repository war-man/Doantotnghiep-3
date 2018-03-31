using DOAN_CHuyenNGanh.Models;
using DOAN_CHuyenNGanh.Models.DTOs;
using DOAN_CHuyenNGanh.Service;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CHuyenNGanh.Controllers
{
    [DynamicRoleAuthorize]
    public class RoleActionController : Controller
    {
        private RoleActionsService _roleactionservice = null;
        private ApplicationDbContext _dbContext = null;
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
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
        public RoleActionController()
        {
            _dbContext = new ApplicationDbContext();
            _roleactionservice = new RoleActionsService();
        }
        // GET: RoleAction
        public ActionResult Index()
        {
            var rolesid = RoleManager.Roles;
            var role = _dbContext.RoleActions.Select(a => a.Action.Id).ToList();
            var temp = _dbContext.RoleActions.ToList();
            var model = new RoleActionViewModel()
            {
                Role= rolesid,
                ActionRolesList = _dbContext.RoleActions.Select(x => new SelectListItem()
                {
                    Selected = role.Contains(x.ActionId),
                    Text = x.RoleId,
                    Value = x.ActionId
                }).Where(a=>a.Selected).ToList()
            };
            return View(model);
        }
       
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            var roleid = _dbContext.RoleActions.Where(a => a.RoleId == id).Select(a=>a.Action.Name).ToList();
            var model = new EditRoleActionViewModel()
            {
                Id = role.Id,
                NameRole = role.Name,
                ActionRolesList = _dbContext.Actions.ToList().Select(x => new SelectListItem()
                {
                    Selected = roleid.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRoleActionViewModel editUser, params string[] selectedRole)
        {
            var roleaction = _dbContext.RoleActions.Where(a=>a.RoleId==editUser.Id).ToList();
            for(int i=0;i<roleaction.Count();i++)
            {
                _dbContext.RoleActions.Remove(roleaction[i]);
                _dbContext.SaveChanges();
            }       
        
            if (ModelState.IsValid)
            {
             
                
                selectedRole = selectedRole ?? new string[] { };
                for(int i=0;i<selectedRole.Length;i++)
                {
                    var temp_role = selectedRole[i];
                    var action = _dbContext.Actions.Where(a => a.Name == temp_role).Select(a=>a.Id).Single();
                    var role = new RoleAction()
                    {
                        ActionId = action,
                        RoleId = editUser.Id
                    };
                    _dbContext.RoleActions.Add(role);
                    _dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something failed.");
            return View();
        }

        public async Task<JsonResult> GetActionRole()
        {
          
            try
            {
                var UserId = User.Identity.GetUserId();
                if (UserId == null)
                {
                    return Json(HttpStatusCode.BadRequest);
                }
                var userIdentity = (ClaimsIdentity)User.Identity;
                var claims = userIdentity.Claims;
                var roleClaimType = userIdentity.RoleClaimType;
                var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                //SetActionDTO setActionDTO = new SetActionDTO
                //{
                //    GetRoleAction = _roleactionservice.GetRoleAction(role.Id)
                //};
                //setActionDTO.SetListRole();
                return Json(_roleactionservice.GetRoleAction("1"), "sucsses", JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json("fail", JsonRequestBehavior.AllowGet);
            }
        }
    }
}