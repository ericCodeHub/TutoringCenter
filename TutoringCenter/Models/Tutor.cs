using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Tutor
    {
        public int TutorID { get; set; }
        public string TutorFirst { get; set; }
        public string TutorLast { get; set; }
        public string TutorEmail { get; set; }
        public ICollection<Visit>Visits { get; set; }
        public ICollection<Request>Requests { get; set; }
    }
}