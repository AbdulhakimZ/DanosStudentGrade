using System.ComponentModel.DataAnnotations;

namespace DanosStudentGrade.Server.Models
{
    /// <summary>
    /// Represents a student entity in the database
    /// </summary>
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        public required string Name { get; set; }
    }
}
