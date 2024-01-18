using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ErasmusSDS.Models;

namespace ErasmusSDS.Controllers
{
    public class DegreeIdViewmodel
    {
        public int DegreeId { get; set; }
    }

    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            var CommentsForCourse = db.Comments.Where(c => c.CourseID == id).ToList();
            ViewBag.CommentsForCourse = CommentsForCourse;

            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create(int? degree_id)
        {
            if (degree_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new DegreeIdViewmodel
            {
                DegreeId = (int) degree_id,
                // Asigna otros valores al modelo según tus necesidades
            };

            ViewBag.CreateCourseData = viewModel;

            ViewData["CreateCourseData"] = degree_id;

            Course course = new Course { DegreeID = (int)degree_id };

            return View(course);
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Name,Information,DegreeID,ECTS,ECTSCardURL")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Name,Information,DegreeID,ECTS,ECTSCardURL")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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

        public ActionResult GetNameById(int id)
        {
            // Supongamos que tienes una lista de cursos o accedes a una base de datos
            // para encontrar el Course con la ID proporcionada
            Course course = db.Courses.Find(id);
            ; 

            if (course != null)
            {
                // Devolver solo el nombre del curso
                return Json(new { Name = course.Name, ECTS = course.ECTS, Url = Url.Action("Details", "Courses", new { id = id }) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Name = "Error: Course not found" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
