using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TutoringCenter.DAL;
using TutoringCenter.Models;
using TutoringCenter.ViewModels;
using PagedList;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TutoringCenter.Controllers
{
    public class StudentController : Controller
    {
        private CenterContext db = new CenterContext();

        // GET: Student
        public ActionResult Index(int? id, string sortOrder, string currentFilter, string searchString, string emailString, int? page)
        {

            var viewModel = new StudentIndexData();

            

            viewModel.Students = db.Students
                .Include(i => i.Requests)
                //.Include(i => i.Requests.Select(r => r.StudentID))
                //.Include(i => i.Visits.Select(v => v.StudentID))
                .OrderBy(i => i.LastName);

            if (id != null)
            {
                ViewBag.StudentID = id.Value;
                ViewBag.StudentName = db.Students.Find(id).FirstName + " " + db.Students.Find(id).LastName;
                viewModel.Requests = viewModel.Students.Where(i => i.StudentID == id.Value).First().Requests;
                viewModel.Visits = viewModel.Students.Where(i => i.StudentID == id.Value).First().Visits;
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParm = sortOrder == "StudentEmail" ? "email_desc" : "StudentEmail";

            if (searchString != null && emailString != null)
            {
                page = 1;
            }
            else
            {
                if (string.IsNullOrEmpty(searchString))
                {
                    searchString = currentFilter;
                } else if (string.IsNullOrEmpty(emailString))
                {
                    emailString = currentFilter;
                }                
                
            }

            

            var students = from s in viewModel.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
                ViewBag.CurrentFilter = searchString;
            } 
            else if(!String.IsNullOrEmpty(emailString))
            {
                students = students.Where(e => e.StudentEmail.Contains(emailString));
                ViewBag.CurrentFilter = emailString;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "StudentEmail":
                    students = students.OrderBy(s => s.StudentEmail);
                    break;
                case "email_desc":
                    students = students.OrderByDescending(s => s.StudentEmail);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            ViewBag.Students = students;
            
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            ViewBag.StudentView = students.ToPagedList(pageNumber, pageSize);

            return View(viewModel);
            //return View(viewModel.ToPagedList(pageNumber, pageSize));
            //return View(students.ToPagedList(pageNumber,pageSize));
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,LastName,FirstName,StudentEmail")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = db.Students.Find(id);
            if (TryUpdateModel(studentToUpdate, "", new string[] { "LastName", "FirstName", "StudentEmail" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.

                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
           
            return View(studentToUpdate);
        }
    

        // GET: Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
                
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
