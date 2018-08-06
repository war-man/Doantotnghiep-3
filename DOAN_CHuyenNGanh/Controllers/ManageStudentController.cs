
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
using System.Data.Entity;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;
using DOAN_CHuyenNGanh.Controllers.ViewModel;
using CsvHelper;
using System.Text;

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
            var isFeedback = TempData["Feedback"];
            if (isFeedback != null)
            {
                ViewBag.isFeedback = isFeedback;
                return View();
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(string Id)
        {
            var temp = db.Students.Include("Parent").Where(a => a.Id == Id).SingleOrDefault();
            return View(temp);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.Entry(student.Parent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            var Id = (from s in db.Students
                      select s.Id).Count();
            var IdParents = (from s in db.Parents
                             select s.Id).Count();
            student.Id = "HS" + (Id + 1);
            student.Parent.Id = "PH" + (IdParents + 1);
            ApplicationUser studentAccount = new ApplicationUser
            {
                UserName = student.email,
                Email = student.email,
            };
            ApplicationUser parentAccount = new ApplicationUser
            {
                UserName = student.Parent.email,
                Email = student.Parent.email,
            };

            student.ApplicationUser = studentAccount;
            student.Parent.ApplicationUser = parentAccount;
            db.Students.Add(student);
            db.Parents.Add(student.Parent);
            db.SaveChanges();
            string studentPassword = $"{student.Id}abc@12345";
            string parentPassword = $"{parentAccount.Id}abc@12345";
            UserManager.AddPassword(studentAccount.Id, studentPassword);
            UserManager.AddToRole(studentAccount.Id, "Student");

            UserManager.AddPassword(parentAccount.Id, parentPassword);
            UserManager.AddToRole(parentAccount.Id, "Parent");

            return View("Index");
        }
        public JsonResult CustomServerSideSearchAction(DataTableAjaxPostModel model)
        {
            try
            {
                // action inside a standard controller
                int filteredResultsCount;
                int totalResultsCount;

                var res = YourCustomSearchFunc(model, out filteredResultsCount, out totalResultsCount);

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

        public IList<StudentViewModel> YourCustomSearchFunc(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var searchBy = (model.search != null) ? model.search.value : null;
            var take = model.length;
            var skip = model.start;

            string sortBy = "Id";
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
                return new List<StudentViewModel>();
            }
            return result;
        }
        public Expression<Func<Student, bool>> BuildDynamicWhereClause(string searchValue)
        {
            return FilterSearch(searchValue);
        }
        public List<StudentViewModel> GetDataFromDbase(string searchBy, int take, int skip, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount)
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
        public ActionResult ClassStudent()
        {
            return View();
        }


        public List<StudentViewModel> GetListNonSearch(Expression<Func<Student, bool>> whereClause, string sortBy, bool sortDir, out int filteredResultsCount, out int totalResultsCount, int take, int skip)
        {
            var classtudent = db.ClassStudent.Include("Class").Include("Year").ToList();
            var result = db.Students
                             .AsExpandable()
                             .Where(whereClause)
                                                          .Select(a => new StudentViewModel
                                                          {
                                                              quequan = a.quequan,
                                                              Id = a.Id,
                                                              lastname_Student = a.lastname_Student,
                                                              firstname_Student = a.firstname_Student,
                                                              sex = a.sex,
                                                              urlImage = a.urlImage,
                                                              address = a.address,
                                                              ApplicationUser = a.ApplicationUser,
                                                              birthDay = a.birthDay,
                                                              birth_place = a.birth_place,
                                                              ClassStudent = db.ClassStudent.Where(s => s.StudentId == a.Id).ToList()
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
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.firstname_Student.ToLower().Contains(srch)));
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.lastname_Student.ToLower().Contains(srch)));

                    break;
                case 2:
                    predicate = predicate.Or(s => searchTerms.Any(srch => s.firstname_Student.ToLower().Contains(srch)));
                    predicate = predicate.And(s => searchTerms.Any(srch => s.lastname_Student.ToLower().Contains(srch)));
                    break;
                case 3:
                    predicate = predicate.And(s => searchTerms.Any(srch => s.firstname_Student.ToLower().Contains(srch)));
                    predicate = predicate.And(s => searchTerms.Any(srch => s.lastname_Student.ToLower().Contains(srch)));
                    break;
                default:
                    break;
            }
            return predicate;
        }

        [HttpPost]
        public ActionResult ExportCSV(ExportStudentViewModel exportStudentViewModel)
        {
            try
            {
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                var csv = new CsvWriter(writer);
                csv.WriteRecords(db.Students.Include("ApplicationUser").Include("Parent").AsEnumerable());
                writer.Flush();
                stream.Position = 0;

                TempData["Feedback"] = "Xuất file thành công";
                return File(stream, "text/csv", "export.csv");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                TempData["Feedback"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ImportCSV(HttpPostedFileBase FileUpload)
        {
            try
            {
                if (FileUpload == null)
                {
                    //TempData[Common.TempDataName.Feedback] = Common.ResultMessages.PlsSelectFile;
                    return RedirectToAction("Index");
                }
                DataTable dt = new DataTable() { };


                if (FileUpload.ContentLength > 0)
                {

                    string fileName = Path.GetFileName(FileUpload.FileName);
                    string path = Path.Combine(@"e:\", fileName);
                    int countBlankContentLines;
                    int countSumLines;
                    try
                    {
                        FileUpload.SaveAs(path);

                        dt = ProcessCSV(path, out countBlankContentLines, out countSumLines);

                        ViewData["Feedback"] = ProcessBulkCopy(dt);

                        ViewData["Feedback"] += string.Format(",Tổng dòng {1},Dòng nội dung trống :{0}", countBlankContentLines, countSumLines);
                    }
                    catch (Exception ex)
                    {

                        log.Error(ex.Message);
                        ViewData["Feedback"] = ex.Message;
                    }
                }
                else
                {

                    ViewData["Feedback"] = "Vui lòng chọn file";
                }


                dt.Dispose();
                TempData["Feedback"] = ViewData["Feedback"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                log.Error(ex);
                TempData["Feedback"] = ex.Message;
                return View("Index");
            }
        }
        public string ProcessBulkCopy(DataTable dt)
        {
            string Feedback = string.Empty;
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            using (SqlConnection conn = new SqlConnection(connString))
            {

                using (var copy = new SqlBulkCopy(conn))
                {

                    conn.Open();
                    copy.DestinationTableName = "CLassStudents";
                    copy.BatchSize = dt.Rows.Count;
                    try
                    {

                        copy.WriteToServer(dt);
                        Feedback = "Upload thành công";
                    }
                    catch (Exception ex)
                    {
                        Feedback = ex.Message;
                    }
                }
            }

            return Feedback;
        }
        public DataTable ProcessCSV(string fileName, out int countBlankContentLines, out int countSumLines)
        {
            string line = string.Empty;
            string[] strArray;
            DataTable dt = new DataTable();
            DataRow row;


            Regex r = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");


            StreamReader sr = new StreamReader(fileName);


            line = sr.ReadLine();
            strArray = r.Split(line);


            Array.ForEach(strArray, s => dt.Columns.Add(s));

            countBlankContentLines = 0;
            countSumLines = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    countBlankContentLines++;
                }
                else
                {
                    row = dt.NewRow();
                    row.ItemArray = r.Split(line);
                    dt.Rows.Add(row);
                }
                countSumLines++;
            }
            sr.Dispose();

            return dt;

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