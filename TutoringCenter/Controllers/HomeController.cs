using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutoringCenter.DAL;
using TutoringCenter.ViewModels;

namespace TutoringCenter.Controllers
{
    public class HomeController : Controller
    {
        private CenterContext db = new CenterContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<AppointmentDataGroup> data = from request in db.Requests
                                                    group request by request.RequestDate into dateGroup
                                                    select new AppointmentDataGroup()
                                                    {
                                                        RequestDate = dateGroup.Key,
                                                        RequestCount = dateGroup.Count()
                                                    };

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}