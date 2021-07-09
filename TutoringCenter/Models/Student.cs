﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName {get; set;}
        public string FirstName { get; set; }
        public string StudentEmail { get; set; }

        public ICollection<Course>Courses { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public ICollection<Request>Requests { get; set; }
    }
}