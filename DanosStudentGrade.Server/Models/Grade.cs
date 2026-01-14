using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanosStudentGrade.Server.Models
{
    /// <summary>
    /// Represents a grade record for a student in a specific course
    /// Uses composite key (Student_Id, Course_Id)
    /// </summary>
    public class Grade
    {
        // Part of composite primary key
        public int Student_Id { get; set; }
        
        // Part of composite primary key
        public int Course_Id { get; set; }

        public required string Course_Name { get; set; }

        public float GradeValue { get; set; }

        // Navigation property to Student
        [ForeignKey(nameof(Student_Id))]
        public Student? Student { get; set; }
    }
}
