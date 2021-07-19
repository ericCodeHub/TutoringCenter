namespace TutoringCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseSignature = c.String(),
                        Section = c.Int(nullable: false),
                        Instructor = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        StudentEmail = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.StudentID)
                .Index(t => t.StudentEmail, unique: true, name: "StudentEmail");
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        TutorID = c.Int(),
                        VisitID = c.Int(),
                        RequestDate = c.DateTime(nullable: false),
                        TimeZone = c.String(),
                        StudentPhone = c.String(),
                        StudentMajor = c.String(),
                        RequestType = c.String(),
                        Instructor = c.String(),
                        Required = c.Boolean(nullable: false),
                        Appointment = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Tutor", t => t.TutorID)
                .ForeignKey("dbo.Visit", t => t.VisitID)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID)
                .Index(t => t.TutorID)
                .Index(t => t.VisitID);
            
            CreateTable(
                "dbo.Tutor",
                c => new
                    {
                        TutorID = c.Int(nullable: false, identity: true),
                        TutorFirst = c.String(),
                        TutorLast = c.String(),
                        TutorEmail = c.String(),
                    })
                .PrimaryKey(t => t.TutorID);
            
            CreateTable(
                "dbo.Visit",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        TutorID = c.Int(nullable: false),
                        VisitStartDateTime = c.DateTime(nullable: false),
                        VisitEndDateTime = c.DateTime(nullable: false),
                        VisitDuration = c.Time(nullable: false, precision: 7),
                        TimeZone = c.String(),
                        Assignment = c.Boolean(nullable: false),
                        PriorCorrespondence = c.Boolean(nullable: false),
                        StudentNotified = c.Boolean(nullable: false),
                        Invoiced = c.Boolean(nullable: false),
                        DoNotReport = c.Boolean(),
                        SessionDetails = c.String(),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Tutor", t => t.TutorID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID)
                .Index(t => t.TutorID);
            
            CreateTable(
                "dbo.Term",
                c => new
                    {
                        TermID = c.String(nullable: false, maxLength: 128),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.TermID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.Course_CourseID })
                .ForeignKey("dbo.Student", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Term", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.Request", "VisitID", "dbo.Visit");
            DropForeignKey("dbo.Visit", "TutorID", "dbo.Tutor");
            DropForeignKey("dbo.Visit", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Visit", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Request", "TutorID", "dbo.Tutor");
            DropForeignKey("dbo.Request", "StudentID", "dbo.Student");
            DropForeignKey("dbo.Request", "CourseID", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Student_StudentID", "dbo.Student");
            DropIndex("dbo.StudentCourse", new[] { "Course_CourseID" });
            DropIndex("dbo.StudentCourse", new[] { "Student_StudentID" });
            DropIndex("dbo.Term", new[] { "Course_CourseID" });
            DropIndex("dbo.Visit", new[] { "TutorID" });
            DropIndex("dbo.Visit", new[] { "CourseID" });
            DropIndex("dbo.Visit", new[] { "StudentID" });
            DropIndex("dbo.Request", new[] { "VisitID" });
            DropIndex("dbo.Request", new[] { "TutorID" });
            DropIndex("dbo.Request", new[] { "CourseID" });
            DropIndex("dbo.Request", new[] { "StudentID" });
            DropIndex("dbo.Student", "StudentEmail");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.Term");
            DropTable("dbo.Visit");
            DropTable("dbo.Tutor");
            DropTable("dbo.Request");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
        }
    }
}
