﻿using System;
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
    public class RequestController : Controller
    {
        private CenterContext db = new CenterContext();

        // GET: Request
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Course).Include(r => r.Student).Include(r => r.Tutor).Include(r => r.Visit);
            return View(requests.ToList());
        }

        // GET: Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName");
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst");
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "TimeZone");
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,StudentID,CourseID,TutorID,VisitID,RequestDate,TimeZone,StudentPhone,StudentMajor,RequestType,Instructor,Required,Appointment,Notes")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature", request.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", request.StudentID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst", request.TutorID);
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "TimeZone", request.VisitID);
            return View(request);
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature", request.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", request.StudentID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst", request.TutorID);
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "TimeZone", request.VisitID);
            return View(request);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,StudentID,CourseID,TutorID,VisitID,RequestDate,TimeZone,StudentPhone,StudentMajor,RequestType,Instructor,Required,Appointment,Notes")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseSignature", request.CourseID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", request.StudentID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorFirst", request.TutorID);
            ViewBag.VisitID = new SelectList(db.Visits, "VisitID", "TimeZone", request.VisitID);
            return View(request);
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
