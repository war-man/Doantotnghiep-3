
using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using LinqKit;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DOAN_CHuyenNGanh.Extentions;
using System.Web.Mvc;
using System.Web.WebPages;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace DOAN_CHuyenNGanh.Controllers
{
    [Authorize]
    public class ManageStudentController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ApplicationDbContext db = new ApplicationDbContext();
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
        // GET: ManageStudent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            var Id = (from s in db.Students
                      select s.Id).Count();
            var IdParents = (from s in db.Parents
                      select s.Id).Count();
            student.Id = "HS" + (Id + 1);
            student.Parent.Id="PH" + (IdParents + 1);
            ApplicationUser studentAccount = new ApplicationUser
            {
                UserName = student.Id,
            };
            ApplicationUser parentAccount = new ApplicationUser
            {
                UserName = student.Parent.Id,
            };

            student.ApplicationUser = studentAccount;
            student.Parent.ApplicationUser = parentAccount;
            db.Students.Add(student);
            db.Parents.Add(student.Parent);
            db.SaveChanges();
            UserManager.AddPassword(student.Id, $"{student.Id}12345");
            UserManager.AddToRoles(student.Id, "Student");
            UserManager.AddPassword(student.Parent.Id, $"{student.Parent.Id}12345");
            UserManager.AddToRoles(student.Parent.Id, "Parent");
            return Json(new
            { result = new { resultCode = "10", message = "Tạo tài khoản và thông tin học sinh và phụ huynh thành công" } }, JsonRequestBehavior.AllowGet);

            return View();
        }
        public JsonResult CustomServerSideSearchAction(DataTableAjaxPostModel model)
        {
            try
            {
                // action inside a standard controller
                int filteredResultsCount;
                int totalResultsCount;

                var res = YourCustomSearchFunc(model, out filteredResultsCount, out totalResultsCount);

                //var result = GetListContactViewModel(res);

                return Json(new
                {
                    // this is what datatables wants sending back
                    model.draw,
                    recordsTotal = totalResultsCount,
                    recordsFiltered = filteredResultsCount,
                    data = res
                });
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Json(new { ResultCode = "99", ResultMessage = "Đã có lỗi xảy ra vui lòng thư lại sau" });
            }
        }
        //public List<Student> GetListContactViewModel(IList<Student> res)
        //{
        //    var result = new List<Student>(res.Count);
        //    foreach (var s in res)
        //    {
        //        // simple remapping adding extra info to found dataset
        //        result.Add(new Student
        //        {
        //            LastName = s.LastName,
        //            FirstName = s.FirstName,
        //            MiddleName = s.MiddleName,
        //            DirectManagerId = s.DirectManagerId,
        //            DOB = s.DOB,
        //            Gender = s.Gender,
        //            Id = s.Id,
        //            StartDate = s.StartDate,
        //            User = s.User,
        //            IsUserCreated = s.IsUserCreated,
        //        });
        //    }
        //    return result;
        //}

        public IList<Student> YourCustomSearchFunc(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "";
            bool sortDir = true;

            if (model.order != null)
            {
                // in this example we just default sort on the 1st column
                sortBy = model.columns[model.order[0].column].data;
                sortDir = model.order[0].dir.ToLower() == "desc";
            }

            // search the dbase taking into consideration table sorting and paging
            var result = GetDataFromDbase(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount);
            if (result == null)
            {
                // empty collection...
                return new List<Student>();
            }
            return result;
        }
        public Expression<Func<Student, bool>> BuildDynamicWhereClause(string searchValue)
        {
            return FilterSearch(searchValue);
        }
        public List<Student> GetDataFromDbase(string searchBy, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount)
        {
            // the example datatable used is not supporting multi column ordering
            // so we only need get the column order from the first column passed to us.        
            var whereClause = BuildDynamicWhereClause(searchBy);

            if (String.IsNullOrEmpty(searchBy) && string.IsNullOrEmpty(sortBy))
            {
                // if we have an empty search then just order the results by Id ascending .OrderBy(sortBy,sortDir)
                sortBy = "Id";
                sortDir = true;
            }
    

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
           return GetListNonSearch(whereClause, sortBy, sortDir, out filteredResultsCount, out totalResultsCount, take, skip);
           

        }
        public List<Student> GetListNonSearch(Expression<Func<Student, bool>> whereClause, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount, int take, int skip)
        {
            var result = db.Students.Include("")
                             .AsExpandable()
                             .Where(whereClause)
                             .Select(s => new Student
                             {
                                 lastname_Student = s.lastname_Student,
                                 firstname_Student = s.firstname_Student,
                                 sex = s.sex,
                                 birthDay = s.birthDay,
                                 phonenumber  = s.phonenumber,
                                 Id = s.Id,
                                 Parent = s.Parent,
                                 address = s.address,
                                 quequan=s.quequan
                             })
                             .OrderBy(sortBy, sortDir)
                             .Skip(skip)
                             .Take(take)
                             .ToList();
            filteredResultsCount = db.Students.Where(whereClause).Count();
            totalResultsCount = db.Students.Count();

            return result;
        }
        public Expression<Func<Student, bool>> FilterSearch(string searchValue)
        {
            // simple method to dynamically plugin a where clause
            var predicate = PredicateBuilder.New<Student>(true); // true -where(true) return all
            if (!String.IsNullOrWhiteSpace(searchValue))
            {
                // as we only have 2 cols allow the user type in name 'firstname lastname' then use the list to search the first and last name of dbase
                var searchTerms = searchValue.Split(' ').ToList().ConvertAll(x => x.ToLower());
                if (searchTerms[0].IsInt())
                {
                    predicate = SearchById(searchTerms, predicate);
                }
                else
                {
                    predicate = SearchByFullName(searchTerms, predicate);
                }
            }
            return predicate;
        }

        public Expression<Func<Student, bool>> SearchById(List<string> searchTerms, Expression<Func<Student, bool>> predicate)
        {
            switch (searchTerms.Count)
            {
                case 1:
                    predicate = predicate.And(s => searchTerms.Any(srch => s.Id.ToString().Contains(srch)));
                    break;
                default:
                    break;
            }
            return predicate;
        }
        public Expression<Func<Student, bool>> SearchByFullName(List<string> searchTerms, Expression<Func<Student, bool>> predicate)
        {
            switch (searchTerms.Count)
            {
                case 1:
                    predicate = predicate.And(s => searchTerms.Any(srch => s.firstname_Student.ToLower().Contains(srch)));
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.lastname_Student.ToLower().Contains(srch)));

                    break;
                case 2:
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.firstname_Student.ToLower().Contains(srch)));
                    predicate = predicate.And(s => searchTerms.Any(srch => s.lastname_Student.ToLower().Contains(srch)));
                    break;
                case 3:
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.firstname_Student.ToLower().Contains(srch)));
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.lastname_Student.ToLower().Contains(srch)));
                    break;
                default:
                    break;
            }
            return predicate;
        }
    }

    public class DataTableAjaxPostModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
    }
    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}