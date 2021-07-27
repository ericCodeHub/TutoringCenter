using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [Required, Display (Name = "Course")]
        public string CourseSignature { get; set; }//subject and number (ex. Bio 150, Engl 101)
        public int Section { get; set; }
        public string Instructor { get; set; }

        public virtual ICollection<Term>Terms { get; set; }
        //public virtual ICollection<Student>Students { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}