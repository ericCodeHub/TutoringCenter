using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Request
    {
        public int RequestID { get; set; }//AppointmentID
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int? TutorID { get; set; }
        [ForeignKey("Visit")]
        public int? VisitID { get; set; }
        public string RequestDate { get; set; }
        public string RequestTime { get; set; }
        public string TimeZone { get; set; }
        public string StudentPhone { get; set; }
        public string StudentMajor { get; set; }
        public string RequestType { get; set; }//phone or video
        public string Instructor { get; set; }
        public bool Required { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentDate{ get; set; }
        public string Notes { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual Visit Visit { get; set; }


    }
}