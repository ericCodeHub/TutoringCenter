using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutoringCenter.DAL;

namespace TutoringCenter.Models
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.StudentEmail).Must(BeUniqueEmail).WithMessage("Email already exists");
        }

        private bool BeUniqueEmail(string email)
        {
            return new CenterContext().Students.FirstOrDefault(x => x.StudentEmail == email) == null;
        }
    }
}