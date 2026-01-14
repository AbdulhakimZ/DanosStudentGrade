using DanosStudentGrade.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DanosStudentGrade.Server.Data
{
    /// <summary>
    /// Database context for the Student Grade application
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite primary key for Grade (Student_Id + Course_Id)
            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.Student_Id, g.Course_Id });

            // Seed initial student data
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Abdulhakim Zeinu" },
                new Student { Id = 2, Name = "Bob Smith" },
                new Student { Id = 3, Name = "Charlie Abera" }
            );

            // Seed initial grade data
            modelBuilder.Entity<Grade>().HasData(
                new Grade { Student_Id = 1, Course_Id = 101, Course_Name = "Math", GradeValue = 85 },
                new Grade { Student_Id = 1, Course_Id = 102, Course_Name = "Physics", GradeValue = 90 },
                new Grade { Student_Id = 2, Course_Id = 101, Course_Name = "Math", GradeValue = 78 },
                new Grade { Student_Id = 2, Course_Id = 103, Course_Name = "Chemistry", GradeValue = 82 },
                new Grade { Student_Id = 3, Course_Id = 102, Course_Name = "Physics", GradeValue = 88 },
                new Grade { Student_Id = 3, Course_Id = 103, Course_Name = "Chemistry", GradeValue = 91 }
            );
        }
    }
}
