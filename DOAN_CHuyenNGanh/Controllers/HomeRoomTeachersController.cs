using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;

namespace DOAN_CHuyenNGanh.Controllers
{
    public class HomeRoomTeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HomeRoomTeachers
        public ActionResult Index()
        {
            var homeRoomTeachers = db.HomeRoomTeachers.Include(h => h.Class).Include(h => h.Teacher).Include(h => h.Year);
            return View(homeRoomTeachers.ToList());
        }

        // GET: HomeRoomTeachers/Details/5
        public ActionResult Details(string id, string year, string teacher)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeRoomTeacher homeRoomTeacher = db.HomeRoomTeachers.Include(h => h.Class).Include(h => h.Teacher).Include(h => h.Year).SingleOrDefault(a => a.Year.Id == year && a.Class.Id == id);
            if (homeRoomTeacher == null)
            {
                return HttpNotFound();
            }
            return View(homeRoomTeacher);
        }

        // GET: HomeRoomTeachers/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "name_Class");
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "name_Teacher");
            ViewBag.YearId = new SelectList(db.Years, "Id", "Name");
            return View();
        }

        // POST: HomeRoomTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,ClassId,YearId")] HomeRoomTeacher homeRoomTeacher)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.HomeRoomTeachers.Add(homeRoomTeacher);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClassId = new SelectList(db.Classes, "Id", "name_Class", homeRoomTeacher.ClassId);
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "name_Teacher", homeRoomTeacher.TeacherId);
                ViewBag.YearId = new SelectList(db.Years, "Id", "Name", homeRoomTeacher.YearId);
                return View(homeRoomTeacher);
            }
            catch (Exception ex)
            {
                ViewBag.ClassId = new SelectList(db.Classes, "Id", "name_Class", homeRoomTeacher.ClassId);
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "name_Teacher", homeRoomTeacher.TeacherId);
                ViewBag.YearId = new SelectList(db.Years, "Id", "Name", homeRoomTeacher.YearId);
                return View(homeRoomTeacher);
            }

        }

        // GET: HomeRoomTeachers/Edit/5
        public ActionResult Edit(string id, string year, string teacher)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeRoomTeacher homeRoomTeacher = db.HomeRoomTeachers.Include(h => h.Class).Include(h => h.Teacher).Include(h => h.Year).SingleOrDefault(a => a.Year.Id == year && a.Class.Id == id);
            if (homeRoomTeacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "Id", "name_Class", homeRoomTeacher.ClassId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "name_Teacher", homeRoomTeacher.TeacherId);
            ViewBag.YearId = new SelectList(db.Years, "Id", "Name", homeRoomTeacher.YearId);
            return View(homeRoomTeacher);
        }

        // POST: HomeRoomTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,ClassId,YearId")] HomeRoomTeacher homeRoomTeacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(homeRoomTeacher).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ClassId = new SelectList(db.Classes, "Id", "name_Class", homeRoomTeacher.ClassId);
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "name_Teacher", homeRoomTeacher.TeacherId);
                ViewBag.YearId = new SelectList(db.Years, "Id", "Name", homeRoomTeacher.YearId);
                return View(homeRoomTeacher);
            }
            catch (Exception ex)
            {
                ViewBag.ClassId = new SelectList(db.Classes, "Id", "name_Class", homeRoomTeacher.ClassId);
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "name_Teacher", homeRoomTeacher.TeacherId);
                ViewBag.YearId = new SelectList(db.Years, "Id", "Name", homeRoomTeacher.YearId);
                return View(homeRoomTeacher);
            }
        }

        // GET: HomeRoomTeachers/Delete/5
        public ActionResult Delete(string id, string year, string teacher)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeRoomTeacher homeRoomTeacher = db.HomeRoomTeachers.SingleOrDefault(a => a.Year.Id == year && a.Class.Id == id);
            if (homeRoomTeacher == null)
            {
                return HttpNotFound();
            }
            return View(homeRoomTeacher);
        }

        // POST: HomeRoomTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string year, string teacher)
        {
            HomeRoomTeacher homeRoomTeacher = db.HomeRoomTeachers.SingleOrDefault(a => a.Year.Id == year && a.Class.Id == id);
            db.HomeRoomTeachers.Remove(homeRoomTeacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
