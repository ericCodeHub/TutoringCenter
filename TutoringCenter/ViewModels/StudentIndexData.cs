using System;
using System.Collections.Generic;
using TutoringCenter.Models;


namespace TutoringCenter.ViewModels
{
    public class StudentIndexData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Visit> Visits { get; set; }

    }
}