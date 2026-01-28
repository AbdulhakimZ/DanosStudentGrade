using DanosStudentGrade.Server.Data;
using DanosStudentGrade.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DanosStudentGrade.Server.Services
{
    /// <summary>
    /// Service for retrieving and calculating student grade statistics
    /// </summary>
    public class StudentGradeService
    {
        private readonly AppDbContext _context;

        public StudentGradeService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves dashboard data including student averages and course averages
        /// </summary>
        public async Task<DashboardDataDto> GetDashboardDataAsync()
        {
            var students = await _context.Students.ToListAsync();
            var grades = await _context.Grades.ToListAsync();

            // Calculate average grade for each student
            var studentAverages = students.Select(s => new StudentAverageDto
            {
                StudentId = s.Id,
                StudentName = s.Name,
                AverageGrade = grades.Where(g => g.Student_Id == s.Id).Select(g => g.GradeValue).DefaultIfEmpty(0).Average()
            }).ToList();

            // Calculate average grade for each course
            var courseAverages = grades.GroupBy(g => g.Course_Name)
                .Select(g => new CourseAverageDto
                {
                    CourseName = g.Key,
                    AverageGrade = g.Average(x => x.GradeValue)
                }).ToList();

            return new DashboardDataDto
            {
                StudentAverages = studentAverages,
                CourseAverages = courseAverages
            };
        }

        public async Task<Student> SaveStudent(Student student)
        {
            var rs = _context.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
