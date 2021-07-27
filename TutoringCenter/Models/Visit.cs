using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Visit
    {
        public int VisitID { get; set; }
        //[ForeignKey("Request")]
        public int RequestID { get; set; } //same thing as appointmentID
        
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int TutorID { get; set; }
        public DateTime VisitStartDateTime { get; set; }
        //public DateTime StartTime { get; set; }
        public DateTime VisitEndDateTime { get; set; }
        [Display(Name = "Duration")]
        public TimeSpan VisitDuration
        {
            get { return VisitEndDateTime.Subtract(VisitStartDateTime); }
            private set { }
        }
        public string TimeZone { get; set; }
        public bool Assignment {get;set;} //did student have assignment to work on?
        [Display(Name = "Prior Correspondence")]
        public bool PriorCorrespondence { get; set; } //did student send work to tutor ahead of time?
        [Display(Name ="Notified")]
        public bool StudentNotified { get; set; }
        public bool Invoiced { get; set; }
        public bool? DoNotReport { get; set; }
        public string SessionDetails { get; set; }
        public virtual Student Student { get; set; }
        //public virtual Request Request { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual Course Course { get; set; }

        //studentID, TutorID, CourseID, AppointmentID

    }
}