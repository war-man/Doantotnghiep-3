
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CHuyenNGanh.Controllers
{
    [Authorize]
    public class ManageStudentController : Controller
    {
        // GET: ManageStudent
        public ActionResult Index()
        {
            return View();
        }
    }
}