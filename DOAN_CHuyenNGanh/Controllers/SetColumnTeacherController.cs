using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CHuyenNGanh.Controllers
{
    [DynamicRoleAuthorize]
    public class SetColumnTeacherController : Controller
    {
        private ApplicationDbContext _dbContext = null;
        public SetColumnTeacherController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: SetColumnTeacher
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var check = _dbContext.Teachers.Any(a => a.ApplicationUser.Id == userId);
            if(check)
            {
                var model = new SetColumnContactViewModel
                {
                    Year = _dbContext.Years.ToList(),
                    applicationUser= userId,
            };
                return View(model);
            }
            return RedirectToAction("Login","Account");

        }
        [HttpPost]
        public ActionResult Index(SetColumnContact setColumnContact)
        {
            var userId = User.Identity.GetUserId();
            var idteacher = _dbContext.Teachers.Where(a => a.ApplicationUser.Id == userId).Single();
            var checknull = _dbContext.SetColumnContact.Any(a => a.TeacherId == idteacher.Id && a.YearId == setColumnContact.YearId);
            var year = _dbContext.Years.Where(a => a.Id == setColumnContact.YearId).Single();
            var setColumnContacts = new SetColumnContact
            {
                mark_5m = setColumnContact.mark_5m,
                mark_15m = setColumnContact.mark_15m,
                mark_45m = setColumnContact.mark_45m,
                YearId = setColumnContact.YearId,
                Year = year,
                Teacher = idteacher,
                TeacherId= idteacher.Id
            };
            var model = new SetColumnContactViewModel
            {
                Year = _dbContext.Years.ToList(),
                mark_5m = setColumnContact.mark_5m,
                mark_15m = setColumnContact.mark_15m,
                mark_45m = setColumnContact.mark_45m,
                applicationUser= userId,
            };
            if (!checknull)
            {
           

                _dbContext.SetColumnContact.Add(setColumnContacts);
                _dbContext.SaveChanges();
             
                TempData["msg"] = "<script>alert('Đã lưu cột điểm');</script>";
                return View(model);
            }
            TempData["msg"] = "<script>alert('Đã thay đổi cột điểm');</script>";
            //3. Mark entity as modified
            _dbContext.Entry(setColumnContacts).State = System.Data.Entity.EntityState.Modified;
            //4. call SaveChanges
            _dbContext.SaveChanges();
            return View(model);
        }
    }
}