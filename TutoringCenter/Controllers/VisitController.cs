using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TutoringCenter.DAL;
using TutoringCenter.Models;

namespace TutoringCenter.Controllers
{
    public class VisitController : Controller
    {
        private CenterContext db = new CenterContext();

        // GET: Visit
        public ActionResult Index()
        {
            var visits = db.Visits.Include(v => v.Course).Include(v => v.Student).Include(v => v.Tutor);
            return View(visits.ToList());
        }

        // GET: Visit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // GET: Visit/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName");
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst");
            return View();
        }

        // POST: Visit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitID,RequestID,StudentID,CourseID,TutorID,VisitStartDateTime,VisitEndDateTime,VisitDuration,TimeZone,Assignment,PriorCorrespondence,StudentNotified,Invoiced,DoNotReport,SessionDetails")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Visits.Add(visit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature", visit.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", visit.StudentID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst", visit.TutorID);
            return View(visit);
        }

        // GET: Visit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature", visit.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", visit.StudentID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst", visit.TutorID);
            return View(visit);
        }

        // POST: Visit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitID,RequestID,StudentID,CourseID,TutorID,VisitStartDateTime,VisitEndDateTime,VisitDuration,TimeZone,Assignment,PriorCorrespondence,StudentNotified,Invoiced,DoNotReport,SessionDetails")] Visit visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature", visit.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", visit.StudentID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst", visit.TutorID);
            return View(visit);
        }

        // GET: Visit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visit visit = db.Visits.Find(id);
            if (visit == null)
            {
                return HttpNotFound();
            }
            return View(visit);
        }

        // POST: Visit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visit visit = db.Visits.Find(id);
            db.Visits.Remove(visit);
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
