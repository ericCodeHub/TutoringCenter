using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Visit
    {
        public int VisitID { get; set; }
        public int RequestID { get; set; } //same thing as appointmentID
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int TutorID { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TimeZone { get; set; }
        public bool Assignment {get;set;} //did student have assignment to work on?
        public bool PriorCorrespondence { get; set; } //did student send work to tutor ahead of time?
        public bool StudentNotified { get; set; }
        public bool Invoiced { get; set; }
        public bool? DoNotReport { get; set; }
        public string SessionDetails { get; set; }
        public Student Student { get; set; }
        public Request Request { get; set; }
        public Tutor Tutor { get; set; }
        public Course Course { get; set; }

        //studentID, TutorID, CourseID, AppointmentID

    }
}