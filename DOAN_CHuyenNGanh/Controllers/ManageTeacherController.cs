using DOAN_CHuyenNGanh.Models;
using DOAN_CHuyenNGanh.Models.ViewModels;
using DOAN_CHuyenNGanh.Service;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CHuyenNGanh.Controllers
{
    [Authorize]
    public class ManageTeacherController : Controller
    {
        private ApplicationDbContext _dbContext = null;

        private ManageTeacherService manageTeacherService = null;
        private ApplicationUserManager _userManager;
        private Teacher teacherChangeInfomation;
        private ApplicationUser teacherAccount;

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
        public ManageTeacherController()
        {
            _dbContext = new ApplicationDbContext();
            manageTeacherService = new ManageTeacherService();
        }
        // GET: ManageTeacher
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(TeacherViewModel teacherViewModel)
        {

            if (ModelState.IsValid)
            {

                using (var tran = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        teacherChangeInfomation = new Teacher();
                        //Thong tin ca nhan
                        teacherChangeInfomation.name_Teacher = teacherViewModel.name_Teacher;
                        teacherChangeInfomation.first_name = teacherViewModel.first_name;
                        teacherChangeInfomation.sex = teacherViewModel.sex;
                        teacherChangeInfomation.people = teacherViewModel.people;
                        teacherChangeInfomation.address = teacherViewModel.address;
                        teacherChangeInfomation.prefecture = teacherViewModel.prefecture;
                        teacherChangeInfomation.city = teacherViewModel.city;
                        teacherChangeInfomation.phuongxa = teacherViewModel.phuongxa;
                        teacherChangeInfomation.birth_day = teacherViewModel.birth_day;
                        teacherChangeInfomation.birth_place = teacherViewModel.birth_place;
                        teacherChangeInfomation.matrimony = teacherViewModel.matrimony;
                        teacherChangeInfomation.name_birth_place = teacherViewModel.name_birth_place;
                        teacherChangeInfomation.Subject = _dbContext.Subjects.SingleOrDefault(a => a.Id == teacherViewModel.subject);
                        teacherChangeInfomation.SubjectId = teacherViewModel.subject;
                        //thông tin liên lạc
                        teacherChangeInfomation.phone_number = teacherViewModel.phone_number;
                        teacherChangeInfomation.email = teacherViewModel.email;
                        teacherChangeInfomation.identity_card_number = teacherViewModel.identity_card_number;

                        //thông tin khác
                        teacherChangeInfomation.status_heal = teacherViewModel.status_heal;
                        teacherChangeInfomation.disabilities = teacherViewModel.disabilities;
                        teacherChangeInfomation.numberBank = teacherViewModel.numberBank;
                        teacherChangeInfomation.nameBank = teacherViewModel.nameBank;
                        teacherChangeInfomation.start_date_social_insurance = teacherViewModel.start_date_social_insurance;
                        teacherChangeInfomation.number_social_insurance = teacherViewModel.number_social_insurance;
                        teacherChangeInfomation.gifted = teacherViewModel.gifted;
                        //Get Id teacher
                        teacherAccount = new ApplicationUser
                        {
                            UserName = teacherViewModel.first_name,
                            Email = teacherViewModel.email,
                        };

                        if (teacherAccount == null)
                        {
                            return Json(new
                            { result = new { resultCode = "01", message = "Xảy ra lỗi khi tạo tài khoản" } }, JsonRequestBehavior.AllowGet);
                        }
                        var Id = (from s in _dbContext.Teachers
                                  select s.Id).Count();
                        teacherChangeInfomation.ApplicationUser = teacherAccount;
                        teacherChangeInfomation.Id = "GV" + (Id + 1);
                        _dbContext.Teachers.Add(teacherChangeInfomation);
                        _dbContext.SaveChanges();

                        // add completed
                        tran.Commit();
                        UserManager.AddPassword(teacherAccount.Id, teacherViewModel.passWord);
                        UserManager.AddToRoles(teacherAccount.Id, "Teacher");
                        return Json(new
                        { result = new { resultCode = "10", message = "Tạo tài khoản và thông tin giáo viên thành công" } }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return Json(new
                        { result = new { resultCode = "02", message = "Tạo tài khoản và thông tin giáo viên không thành công" } }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            var errors = from modelstate in ModelState.AsQueryable().Where(f => f.Value.Errors.Count > 0) select new { Title = modelstate.Key };
            return Json(new
            {
                result = new
                {
                    resultCode = "02",
                    errors,
                    message = ModelState.Values.SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)
                }
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Edit(EditInfoTeacherViewModel teacherViewModel)
        {

            if (ModelState.IsValid)
            {

                using (var tran = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Teacher teacherChangeInfomation = _dbContext.Teachers.Include("ApplicationUser").SingleOrDefault(a => a.Id == teacherViewModel.Id);
                        //Thong tin ca nhan
                        teacherChangeInfomation.Id = teacherViewModel.Id;
                        teacherChangeInfomation.name_Teacher = teacherViewModel.name_Teacher;
                        teacherChangeInfomation.first_name = teacherViewModel.first_name;
                        teacherChangeInfomation.sex = teacherViewModel.sex;
                        teacherChangeInfomation.people = teacherViewModel.people;
                        teacherChangeInfomation.address = teacherViewModel.address;
                        teacherChangeInfomation.prefecture = teacherViewModel.prefecture;
                        teacherChangeInfomation.city = teacherViewModel.city;
                        teacherChangeInfomation.phuongxa = teacherViewModel.phuongxa;
                        teacherChangeInfomation.birth_day = teacherViewModel.birth_day;
                        teacherChangeInfomation.birth_place = teacherViewModel.birth_place;
                        teacherChangeInfomation.matrimony = teacherViewModel.matrimony;
                        teacherChangeInfomation.name_birth_place = teacherViewModel.name_birth_place;

                        //thông tin liên lạc
                        teacherChangeInfomation.phone_number = teacherViewModel.phone_number;
                        teacherChangeInfomation.email = teacherViewModel.email;
                        teacherChangeInfomation.identity_card_number = teacherViewModel.identity_card_number;

                        //thông tin khác
                        teacherChangeInfomation.status_heal = teacherViewModel.status_heal;
                        teacherChangeInfomation.disabilities = teacherViewModel.disabilities;
                        teacherChangeInfomation.numberBank = teacherViewModel.numberBank;
                        teacherChangeInfomation.nameBank = teacherViewModel.nameBank;
                        teacherChangeInfomation.start_date_social_insurance = teacherViewModel.start_date_social_insurance;
                        teacherChangeInfomation.number_social_insurance = teacherViewModel.number_social_insurance;
                        teacherChangeInfomation.gifted = teacherViewModel.gifted;
                        teacherChangeInfomation.status_deleted = false;
                        teacherChangeInfomation.Subject = _dbContext.Subjects.SingleOrDefault(a=>a.Id== teacherViewModel.subject);
                        teacherChangeInfomation.SubjectId = teacherViewModel.subject;
                        //Get Id teacher

                        _dbContext.SaveChanges();

                        // add completed
                        tran.Commit();
                        if(!string.IsNullOrEmpty(teacherViewModel.passWord))
                        {
                            UserManager.ChangePassword(teacherChangeInfomation.ApplicationUser.Id, teacherChangeInfomation.ApplicationUser.PasswordHash, teacherViewModel.passWord);
                        }
                        
                        return Json(new
                        { result = new { resultCode = "10", message = "Sửa thông tin tài khoản và thông tin giáo viên thành công" } }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        return Json(new
                        { result = new { resultCode = "02", message = "Sửa thông tin tài khoản và thông tin giáo viên không thành công" } }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            var errors = from modelstate in ModelState.AsQueryable().Where(f => f.Value.Errors.Count > 0) select new { Title = modelstate.Key };
            return Json(new
            {
                result = new
                {
                    resultCode = "02",
                    errors,
                    message = ModelState.Values.SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)
                }
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Delete(string id)
        {
            var teacher = _dbContext.Teachers.SingleOrDefault(a => a.Id == id);
            if (teacher == null)
            {
                return Json(new
                { result = new { resultCode = "02", message = "Không có thông tin giáo viên này!" } }, JsonRequestBehavior.AllowGet);
            }
            if(!teacher.status_deleted)
            {
                teacher.status_deleted = !teacher.status_deleted;
            }
            else
            {
                teacher.status_deleted = !teacher.status_deleted;
            }
            _dbContext.SaveChanges();
            return Json(new
            { result = new { resultCode = "Đã thay đổi trạng thái giáo viên thành công", statusdeleted= teacher.status_deleted } }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetTeacher(string id)
        {
            Teacher teacher = new Teacher();
            teacher = _dbContext.Teachers.Include("ApplicationUser").SingleOrDefault(a => a.Id == id);
            if(teacher==null)
            {
                return Json(new
                { result = new { resultCode = "02", message = "Không có thông tin giáo viên này!" } }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            { result = new { resultCode = "10", data = teacher } }, JsonRequestBehavior.AllowGet);
        }

        private async Task<ApplicationUser> CreateAccountForTeacherAsync(string email, string passWord, string userName)
        {
            ApplicationUser teacherAccount = new ApplicationUser { UserName = userName, Email = email };
            var result = await UserManager.CreateAsync(teacherAccount, passWord);
            if (result.Succeeded)
            {
                var addroles_teacher = await UserManager.AddToRolesAsync(teacherAccount.Id, "Teacher");
                if (addroles_teacher.Succeeded)
                {
                    return teacherAccount;
                }
                return null;
            }
            return null;
        }
        [HttpPost]
        public JsonResult CheckEmailAndUserName(string email)
        {
            var user= UserManager.FindByEmail(email);
            if(user==null)
            {
                return Json(new
                { result = new { resultCode = "03", message = "Có thể sử dụng email này" } }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            { result = new { resultCode = "01", message = "Email đã tồn tại" } }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListTeacher()
        {
            try
            {
                var result = manageTeacherService.GetListTeacher();
                return Json(result, "Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, "Fail", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Schedule(string Id)
        {

            Teacher teacher = _dbContext.Teachers.SingleOrDefault(a => a.Id == Id);
            if (teacher == null)
            {
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
    }
}