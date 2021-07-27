using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutoringCenter.Models
{
    public class Tutor
    {

        public int TutorID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "Tutor F_Name")]
        public string TutorFirst { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Tutor L_Name")]
        public string TutorLast { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string TutorEmail { get; set; }
        public virtual ICollection<Visit>Visits { get; set; }
        public virtual ICollection<Request>Requests { get; set; }
    }
}