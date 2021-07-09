using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TutoringCenter.Models;

namespace TutoringCenter.DAL
{
    public class DataInitializer : System.Data.Entity. DropCreateDatabaseAlways<CenterContext>
    {
        protected override void Seed(CenterContext context)
        {
            var students = new List<Student>
            {
                new Student{FirstName="Carson",LastName="Alexander",StudentEmail="alex.carson@myschool.edu"},
                new Student{FirstName="Meredith",LastName="Alonso",StudentEmail="meredith.alonso@myschool.edu"},
                new Student{FirstName="Arturo",LastName="Anand",StudentEmail="art.anand@myschool.edu"},
                new Student{FirstName="Gytis",LastName="Barzdukas",StudentEmail="gytis.barzdukas@myschool.edu"},
                new Student{FirstName="Yan",LastName="Li",StudentEmail="yan.li@myschool.edu"},
                new Student{FirstName="Peggy",LastName="Justice",StudentEmail="peggy.justice@myschool.edu"},
                new Student{FirstName="Laura",LastName="Norman",StudentEmail="laura.norman@myschool.edu"},

            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{CourseSignature="Eng 101", Section=1, Instructor="John Smith"},
                new Course{CourseSignature="Eng 101", Section=2, Instructor="Larry David"},
                new Course{CourseSignature="Eng 290", Section=4,Instructor="Courtney Bates"},
                new Course{CourseSignature="CJM 101", Section=7, Instructor="Laura Landry"},

            };

            courses.ForEach(c => context.Courses.Add(c));
            context.SaveChanges();

            var terms = new List<Term>
            { 
                new Term{TermID = "Fall 2019" },
                new Term{TermID="Spring 2020"},
                new Term{TermID="Summer 2020"},
                new Term{TermID="Fall 2020"},
            };

            terms.ForEach(t => context.Terms.Add(t));
            context.SaveChanges();

            var tutors = new List<Tutor>
            {
                new Tutor{TutorLast="Michaels", TutorFirst="Anne", TutorEmail="anne.michaels@myschool.edu"},
                new Tutor{TutorLast="Wenstrup", TutorFirst="Charles", TutorEmail="charles.wenstrup@myschool.edu"},
                new Tutor{TutorLast="Richie", TutorFirst="Marcia", TutorEmail="marcia.richie@myschool.edu"},
                new Tutor{TutorLast="Kent", TutorFirst="Bruce", TutorEmail="bruce.kent@myschool.edu"},
            };

            terms.ForEach(t => context.Tutors.Add(t));
            context.SaveChanges();

            var requests = new List<Request>
            {
                new Request{RequestDate=DateTime.Parse("2020-09-01"), RequestTime=DateTime.Parse("09:00:00"), TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="Undeclared", RequestType="phone", Instructor="Charles Smith", Required=false, AppointmentTime=DateTime.Parse("13:00:00"), AppointmentDate=DateTime.Parse("2020-15-01"), StudentID=1,CourseID=3},

                new Request{RequestDate=DateTime.Parse("2020-10-01"), RequestTime=DateTime.Parse("09:00:00"), TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="CJM", RequestType="phone", Instructor="JoJo Johnson", Required=false, AppointmentTime=DateTime.Parse("13:00:00"), AppointmentDate=DateTime.Parse("2020-16-01"), StudentID=2,CourseID=1},

                new Request{RequestDate=DateTime.Parse("2020-12-01"), RequestTime=DateTime.Parse("09:24:00"), TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="Education", RequestType="phone", Instructor="Robert Pickle", Required=true, AppointmentTime=DateTime.Parse("13:00:00"), AppointmentDate=DateTime.Parse("2020-18-01"), StudentID=3,CourseID=2},

                new Request{RequestDate=DateTime.Parse("2020-16-01"), RequestTime=DateTime.Parse("11:11:00"), TimeZone="Central", StudentPhone="555-555-5555", StudentMajor="Physics", RequestType="phone", Instructor="Wanda Stark", Required=false, AppointmentTime=DateTime.Parse("13:00:00"), AppointmentDate=DateTime.Parse("2020-19-01"), StudentID=4,CourseID=2},

                new Request{RequestDate=DateTime.Parse("2020-17-01"), RequestTime=DateTime.Parse("10:23:00"), TimeZone="Mountain", StudentPhone="555-555-5555", StudentMajor="Education", RequestType="video", Instructor="Graham Carlson", Required=true, AppointmentTime=DateTime.Parse("13:00:00"), AppointmentDate=DateTime.Parse("2020-21-01"), StudentID=3,CourseID=4},

            };
            requests.ForEach(r => context.Requests.Add(r));
            context.SaveChanges();

            var visits = new List<Visit>
            {
                new Visit{RequestID=1,VisitDate=DateTime.Parse("2020-15-01"), StartTime=DateTime.Parse("13:00:00"), EndTime=DateTime.Parse("13:42:00"), TimeZone="Eastern", Assignment=true, PriorCorrespondence=true, StudentNotified=false, Invoiced=false, SessionDetails="Alex and I reviewd his rough draft and worked on organization.  He is going to consider some of the suggestions and may return for another session after revising.", StudentID=1, CourseID=3, TutorID=4},

                new Visit{RequestID=2,VisitDate=DateTime.Parse("2020-16-01"), StartTime=DateTime.Parse("13:00:00"), EndTime=DateTime.Parse("13:35:00"), TimeZone="Eastern", Assignment=true, PriorCorrespondence=true, StudentNotified=false, Invoiced=false, SessionDetails="Alex and I reviewd his rough draft and worked on organization.  He is going to consider some of the suggestions and may return for another session after revising.", StudentID=2, CourseID=1, TutorID=2},

                new Visit{RequestID=1,VisitDate=DateTime.Parse("2020-18-01"), StartTime=DateTime.Parse("13:00:00"), EndTime=DateTime.Parse("13:30:00"), TimeZone="Eastern", Assignment=false, PriorCorrespondence=false, StudentNotified=false, Invoiced=false, SessionDetails="Alex and I reviewd his rough draft and worked on organization.  He is going to consider some of the suggestions and may return for another session after revising.", StudentID=3, CourseID=2, TutorID=2},
            };

            visits.ForEach(v => context.Requests.Add(v));
            context.SaveChanges();
        }
    }
}