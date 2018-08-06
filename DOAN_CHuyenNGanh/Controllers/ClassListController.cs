using DOAN_CHuyenNGanh.Controllers.ViewModel;
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
    public class ClassListController : Controller
    {
        private ApplicationDbContext _dbContext = null;
        public ClassListController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult EditIndex()
        {

            return View();
        }
        public ActionResult ListClassExams()
        {
            
            return View(_dbContext.FocusExamses.Include("Semester").Include("Subject").Include("Year").ToList());
        }
        public ActionResult SortClassExams()
        {
            var userId = User.Identity.GetUserId();
           // var teacher = _dbContext.Teachers.Where(a => a.ApplicationUser.Id == userId).Single();
         
           

            var senester = _dbContext.Semesters.ToList();
            var year= _dbContext.Years.ToList();
            var subject = _dbContext.Subjects.ToList();
            //var column = _dbContext.SetColumnContact.Where(a => a.TeacherId == teacher.Id &&).Single();
            var model = new SortClassExmasViewModel
            {
                Semester= senester,
                Year=year,
                TeacherId = userId,
                Subject = subject
            };
            return View(model);
        }
        // GET: ClassList
        public ActionResult Index()
        {
            var teacherid = User.Identity.GetUserId();
            if (_dbContext.Teachers.Any(a=>a.ApplicationUser.Id== teacherid))
            {
                var teacher = _dbContext.Teachers.Include("Subject").Where(a => a.ApplicationUser.Id == teacherid).Single();
                var classview = _dbContext.ClassTeacher.Include("Class").Where(a => a.TeacherId == teacher.Id).ToList();
                var semester = _dbContext.Semesters.ToList();
                var year = _dbContext.Years.ToList();
                var classes = _dbContext.Classes.ToList();
                var viewmodel = new ClassListViewModel
                {
                    ClassTeacher=classview,
                    Teacher=teacher,
                    Semester=semester,
                    Year=year,
                    Class=classes,
                    
                    
                };
                return View(viewmodel);
            }
            else if(User.IsInRole("Admin")){
                return View("MarkControl");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult MarkControl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MarkClassControl(ContactAdminViewModel contactViewModel)
        {

                var listSudent = _dbContext.ClassStudent.Where(a => a.Class.Id == contactViewModel.ClassNameId&&a.YearId==contactViewModel.YearId).ToList();
                List<Contact> list_Contact = new List<Contact>();


            for (int i = 0; i < listSudent.Count; i++)
            {
                var temp = new Contact() { };
                temp.CLassId = contactViewModel.ClassNameId;
                temp.SubjectId = contactViewModel.SubjectId;
                temp.SemesterId = contactViewModel.SemesterId;
                temp.YearId = contactViewModel.YearId;
                temp.StudentId = listSudent[i].StudentId;
                var check = _dbContext.Contacts.Any(a => a.CLassId == contactViewModel.ClassNameId && a.SubjectId == contactViewModel.SubjectId && a.SemesterId == contactViewModel.SemesterId && a.YearId == contactViewModel.YearId && a.StudentId == temp.StudentId);
                if (!check)
                {
                    _dbContext.Contacts.Add(temp);
                    _dbContext.SaveChanges();

                }

            }
                //var list = _dbContext.Contacts.Include("Student").Include("Class").Include("Semester").Include("Year").Where(a => a.CLassId == contactViewModel.ClassId && a.SubjectId == contactViewModel.SubjectId && a.SemesterId == contactViewModel.SemesterId && a.YearId == contactViewModel.YearId).ToList();
                //TempData["list"] = list;
                //return RedirectToAction("Edit");

            
            var list2 = _dbContext.Contacts.Include("Subject").Include("Student").Include("Class").Include("Semester").Include("Year").Where(a => a.CLassId == contactViewModel.ClassNameId && a.SubjectId == contactViewModel.SubjectId && a.SemesterId == contactViewModel.SemesterId && a.YearId == contactViewModel.YearId).ToList();
            if(list2.Count.Equals(0))
            {
                return RedirectToAction("MarkControl");
            }
            TempData["list"] = list2;
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            var teacherid = User.Identity.GetUserId();
            if (_dbContext.Teachers.Any(a => a.ApplicationUser.Id == teacherid))
            {
              
                var teacher = _dbContext.Teachers.Include("Subject").Where(a => a.ApplicationUser.Id == teacherid).Single();
                var listSudent = _dbContext.ClassStudent.Where(a => a.Class.Id == contact.CLassId).ToList();
                List<Contact> list_Contact = new List<Contact>();

           
                for (int i=0;i<listSudent.Count;i++)
                {
                    var temp = new Contact() { };
                    temp.CLassId = contact.CLassId;
                    temp.SubjectId = teacher.Subject.Id;
                    temp.SemesterId = contact.SemesterId;
                    temp.YearId = contact.YearId;
                    temp.StudentId= listSudent[i].StudentId;
                    var check = _dbContext.Contacts.Any(a => a.CLassId == contact.CLassId && a.SubjectId == teacher.Subject.Id && a.SemesterId == contact.SemesterId && a.YearId == contact.YearId && a.StudentId == temp.StudentId);
                    if (!check)
                    {
                        _dbContext.Contacts.Add(temp);
                        _dbContext.SaveChanges();
                       
                    }
                                       
                }
                var list = _dbContext.Contacts.Include("Student").Include("Class").Include("Semester").Include("Year").Where(a => a.CLassId == contact.CLassId && a.SubjectId == teacher.Subject.Id && a.SemesterId == contact.SemesterId && a.YearId == contact.YearId).ToList();
                TempData["list"] = list;
                return RedirectToAction("Edit");
      
            }
            var list2 = _dbContext.Contacts.Where(a => a.CLassId == contact.CLassId && a.SubjectId == contact.SubjectId && a.SemesterId == contact.SemesterId && a.YearId == contact.YearId).ToList();
            return View("Edit", list2);

        }
            [HttpGet]
            public ActionResult Edit( List<Contact> passContact)
            {
            List<Contact> list = (List<Contact>)TempData["list"];
            TempData["list"] = list;
            var userid = User.Identity.GetUserId();
            var teacher = _dbContext.Teachers.Where(a => a.ApplicationUser.Id == userid).SingleOrDefault();
            var year = list[0].YearId;
            var column = new SetColumnContact();
            if (teacher == null)
            {
                column.mark_5m = 5;
                column.mark_45m = 4;
                column.mark_15m = 5;
            }
            else
            {
                 column = _dbContext.SetColumnContact.Where(a => a.TeacherId == teacher.Id && a.YearId == year).SingleOrDefault();
            }
          

            var model = new ContactViewModel
            {
                Contact=list,
                SetColumnContact=column
            };
            return View(model);
        }
    }
}