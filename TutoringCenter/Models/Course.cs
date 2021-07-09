﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseSignature { get; set; }//subject and number (ex. Bio 150, Engl 101)
        public int Section { get; set; }
        public string Instructor { get; set; }

        public ICollection<Term>Terms { get; set; }
        public ICollection<Student>Students { get; set; }
    }
}