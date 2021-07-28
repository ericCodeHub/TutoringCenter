using TutoringCenter.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TutoringCenter.DAL
{
    public class CenterContext : DbContext
    {

        public CenterContext() : base("CenterContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student>Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Request>Requests { get; set; }
        public DbSet<Visit>Visits { get; set; }
        public DbSet<Tutor>Tutors { get; set; }
        public DbSet<Term>Terms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Student>().HasIndex(s => s.StudentEmail).IsUnique();

            

        }
    }
}