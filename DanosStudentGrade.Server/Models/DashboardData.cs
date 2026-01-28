namespace DanosStudentGrade.Server.Models
{
    public class StudentAverageDto
    {
        public int StudentId { get; set; }
        public required string StudentName { get; set; }
        public double AverageGrade { get; set; }
    }

    public class CourseAverageDto
    {
        public required string CourseName { get; set; }
        public double AverageGrade { get; set; }
    }

    public class DashboardDataDto
    {
        public required List<StudentAverageDto> StudentAverages { get; set; }
        public required List<CourseAverageDto> CourseAverages { get; set; }
    }
}
