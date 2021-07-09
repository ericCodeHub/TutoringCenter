using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int? TutorID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime RequestTime { get; set; }
        public string TimeZone { get; set; }
        public string StudentPhone { get; set; }
        public string StudentMajor { get; set; }
        public string RequestType { get; set; }//phone or video
        public string Instructor { get; set; }
        public bool Required { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime AppointmentDate{ get; set; }
        public string Notes { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual Tutor Tutor { get; set; }


    }
}