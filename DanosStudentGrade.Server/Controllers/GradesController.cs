using DanosStudentGrade.Server.Models;
using DanosStudentGrade.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DanosStudentGrade.Server.Controllers
{
    /// <summary>
    /// API controller for grade-related operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly StudentGradeService _service;

        public GradesController(StudentGradeService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET /api/grades - Returns all dashboard data (student averages and course averages)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetDashboardDataAsync();
            return Ok(data);
        }

        [HttpPost("student")]
        public async Task<IActionResult> SaveStudent([FromBody] Student studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is required");
            }

            if (string.IsNullOrWhiteSpace(studentDto.Name))
            {
                return BadRequest("Student name is required");
            }
            try
            {
                var savedStudent = await _service.SaveStudent(studentDto);
                return CreatedAtAction(nameof(Get), new { id = savedStudent.Id }, savedStudent);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("submitNewGrade")]
        public async Task<IActionResult> SubmitNewGrade([FromBody] Student studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is required");
            }

            if (string.IsNullOrWhiteSpace(studentDto.Name))
            {
                return BadRequest("Student name is required");
            }
            try
            {
                var savedStudent = await _service.SaveStudent(studentDto);
                return CreatedAtAction(nameof(Get), new { id = savedStudent.Id }, savedStudent);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
