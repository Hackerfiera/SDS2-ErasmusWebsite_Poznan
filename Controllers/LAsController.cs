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
    public class LAsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LAs
        public ActionResult Index()
        {
            return View(db.LAs.ToList());
        }

        // GET: LAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LA lA = db.LAs.Find(id);
            if (lA == null)
            {
                return HttpNotFound();
            }
            return View(lA);
        }

        // GET: LAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LAID,NombreEstudiante,status")] LA lA)
        {
            if (ModelState.IsValid)
            {
                
                db.LAs.Add(lA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lA);
        }

        // GET: LAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LA lA = db.LAs.Find(id);
            if (lA == null)
            {
                return HttpNotFound();
            }
            return View(lA);
        }

        // POST: LAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LAID,NombreEstudiante,status")] LA lA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lA);
        }

        // GET: LAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LA lA = db.LAs.Find(id);
            if (lA == null)
            {
                return HttpNotFound();
            }
            return View(lA);
        }

        // POST: LAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LA lA = db.LAs.Find(id);
            db.LAs.Remove(lA);
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

        public ActionResult UpdateStatus(int LAID)
        {
            var la = db.LAs.Find(LAID);

            if (la != null)
            {
                la.status = "signed";
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
