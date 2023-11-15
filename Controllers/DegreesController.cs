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
    public class DegreesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Degrees
        public ActionResult Index()
        {
            return View(db.Degrees.ToList());
        }

        // GET: Degrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }

            var coursesForDegree = db.Courses.Where(c => c.DegreeID == id).ToList();
            degree = db.Degrees.FirstOrDefault(d => d.DegreeID == id);

            ViewBag.CoursesForDegree = coursesForDegree;

            return View(degree);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DegreeID,Name,Information")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Degrees.Add(degree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(degree);
        }

        // GET: Degrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DegreeID,Name,Information")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Degree degree = db.Degrees.Find(id);
            db.Degrees.Remove(degree);
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
