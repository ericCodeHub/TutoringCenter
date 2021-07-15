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
                new Student{FirstName="Gytis",LastName="Barzdukas",StudentEmail="gytis.barzdukas@myschool.edu"},
                new Student{FirstName="Yan",LastName="Li",StudentEmail="yan.li@myschool.edu"},
                new Student{FirstName="Peggy",LastName="Justice",StudentEmail="peggy.justice@myschool.edu"},
                new Student{FirstName="Laura",LastName="Norman",StudentEmail="laura.norman@myschool.edu"},
                new Student{FirstName="Arturo",LastName="Anand",StudentEmail="art.anand@myschool.edu"},

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

            tutors.ForEach(t => context.Tutors.Add(t));
            context.SaveChanges();

            var reqDate1a = new DateTime(2020, 1, 24, 13, 10, 0);
            var reqDate1b = new DateTime(2020, 1, 29, 14, 00, 0);
            var reqDate2a = new DateTime(2020, 1, 20, 9, 23, 0);
            var reqDate2b = new DateTime(2020, 1, 29, 9, 00, 0);

            var requests = new List<Request>
            {
                new Request{RequestDate= new DateTime(2020, 1, 9, 9, 0, 0), TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="Undeclared", RequestType="phone", Instructor="Charles Smith", Required=false, Appointment=new DateTime(2020, 1, 15, 13, 0, 0), StudentID=1,CourseID=3},

                new Request{RequestDate=new DateTime(2020, 1,10, 9, 0, 0), TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="CJM", RequestType="phone", Instructor="JoJo Johnson", Required=false, Appointment=new DateTime(2020, 1,16, 13, 0, 0), StudentID=2,CourseID=1},

                //new DateTime(2020, 1,16, 13, 0, 0).ToString("yyyy-MM-dd"), new DateTime(2020, 1,16, 13, 0, 0).ToString("HH:mm:ss")

                new Request{RequestDate=new DateTime(2020, 1, 12, 9, 24, 0), TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="Education", RequestType="phone", Instructor="Robert Pickle", Required=true, Appointment=new DateTime(2020, 1, 18, 13, 0, 0), StudentID=3,CourseID=2},

                //DateTime.Parse("2020-12-01")
                //new DateTime(2020, 1, 12, 9, 24, 0).ToString("yyyy-MM-dd"), new DateTime(2020, 1, 12, 9, 24, 0).ToString("HH:mm:ss")
                //new DateTime(2020, 1,18, 13, 0, 0).ToString("yyyy-MM-dd"), new DateTime(2020, 1, 18, 13, 0, 0).ToString("HH:mm:ss")

                new Request{RequestDate=new DateTime(2020, 1, 16, 11, 11, 0), TimeZone="Central", StudentPhone="555-555-5555", StudentMajor="Physics", RequestType="phone", Instructor="Wanda Stark", Required=false,Appointment=new DateTime(2020, 1, 19, 13, 0, 0), StudentID=4,CourseID=2},

                //DateTime.Parse("2020-16-01")
                //new DateTime(2020, 1, 16, 11, 11, 0).ToString("yyyy-MM-dd"), new DateTime(020, 1, 16, 11, 11, 0).ToString("HH:mm:ss")
                //new DateTime(2020, 1, 19, 13, 0, 0).ToString("yyyy-MM-dd"), new DateTime(2020, 1, 19, 13, 0, 0).ToString("HH:mm:ss")

                new Request{RequestDate=new DateTime(2020, 1, 17, 10, 23, 0), TimeZone="Mountain", StudentPhone="555-555-5555", StudentMajor="Education", RequestType="video", Instructor="Graham Carlson", Required=true, Appointment=new DateTime(2020, 1, 21, 13, 0, 0), StudentID=3,CourseID=4},

                //DateTime.Parse("2020-17-01")
                //new DateTime(2020, 1, 17, 10, 23, 0).ToString("yyyy-MM-dd"), new DateTime(2020, 1, 17, 10, 23, 0).ToString("HH:mm:ss")
                //new DateTime(2020, 1, 21, 13, 0, 0).ToString("yyyy-MM-dd"), new DateTime(2020, 1, 21, 13, 0, 0).ToString("HH:mm:ss")

                new Request{RequestDate=reqDate1a, TimeZone="Mountain", StudentPhone="555-555-5555", StudentMajor="Physics", RequestType="video", Instructor="Graham Carlson", Required=true,Appointment=reqDate1b, StudentID=4,CourseID=4},

                new Request{RequestDate=reqDate2a, TimeZone="Eastern", StudentPhone="555-555-5555", StudentMajor="Physics", RequestType="phone", Instructor="Norbert Nordstrom", Required=false, Appointment=reqDate2b, StudentID=7,CourseID=1},


            };
            requests.ForEach(r => context.Requests.Add(r));
            context.SaveChanges();

            var myDate1a = new DateTime(2020, 1, 15, 13, 0, 0);
            var myDate2a = new DateTime(2020, 1, 15, 13, 42, 0);
            var myDate1b = new DateTime(2020, 1, 16, 13, 0, 0);
            var myDate2b = new DateTime(2020, 1, 16, 13, 35, 0);
            var myDate1c = new DateTime(2020, 1, 18, 13, 0, 0);
            var myDate2c = new DateTime(2020, 1, 18, 13, 30, 0);

            var visits = new List<Visit>
            {
                new Visit{RequestID=1,VisitStartDateTime=myDate1a, VisitEndDateTime=myDate2a, TimeZone="Eastern", Assignment=true, PriorCorrespondence=true, StudentNotified=false, Invoiced=false, SessionDetails="Alex and I reviewed his rough draft and worked on organization.  He is going to consider some of the suggestions and may return for another session after revising.", StudentID=1, CourseID=3, TutorID=4},

                //new DateTime(2020, 1, 15, 13, 0, 0).ToString("yyyy-MM-dd")

                new Visit{RequestID=2,VisitStartDateTime=myDate1b, VisitEndDateTime=myDate2b, TimeZone="Eastern", Assignment=true, PriorCorrespondence=true, StudentNotified=false, Invoiced=false, SessionDetails="Alex and I reviewed his rough draft and worked on organization.  He is going to consider some of the suggestions and may return for another session after revising.", StudentID=2, CourseID=1, TutorID=3},

                new Visit{RequestID=3,VisitStartDateTime=myDate1c, VisitEndDateTime=myDate2c, TimeZone="Eastern", Assignment=false, PriorCorrespondence=false, StudentNotified=false, Invoiced=false, SessionDetails="Alex and I reviewed his rough draft and worked on organization.  He is going to consider some of the suggestions and may return for another session after revising.", StudentID=3, CourseID=2, TutorID=2},
            };

            visits.ForEach(v => context.Visits.Add(v));
            context.SaveChanges();
        }
    }
}