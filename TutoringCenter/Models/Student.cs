
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TutoringCenter.DAL;
using TutoringCenter.Models;

namespace TutoringCenter.Models
{
    
    public class Student : IValidatableObject
    {
        public int StudentID { get; set; }
        public string LastName {get; set;}
        public string FirstName { get; set; }
        [StringLength(100)]//necessary so that error is not thrown on making email Index Unique
        [Index(nameof(StudentEmail), IsUnique = true)]
        public string StudentEmail { get; set; }

        public virtual ICollection<Course>Courses { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Request>Requests { get; set; }

        //********************
        //see https://www.codeproject.com/Articles/1130113/Best-Ways-of-Implementing-Uniqueness-or-Unique-Key for how following helps check and provide error handling for unique value
        //********************
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            CenterContext db = new CenterContext();
            var validateName = db.Students.FirstOrDefault(s => s.StudentEmail == StudentEmail && s.StudentID != StudentID);

            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult("Email already exists, double check email and check to see if this student already exists in the db.", new[] { "StudentEmail" });
                yield return errorMessage;
            }
            else
            {
                yield return ValidationResult.Success;
            }
        }
    }

}