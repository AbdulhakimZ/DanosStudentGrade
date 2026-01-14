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
    }
}
