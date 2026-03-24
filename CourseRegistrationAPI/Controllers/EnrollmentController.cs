using CourseRegistrationAPI.DTOs;
using CourseRegistrationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        // Injicerar EnrollmentService via konstruktorn
        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // GET: api/enrollments - Hämtar alla registreringar
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            return Ok(enrollments);
        }

        // GET: api/enrollments/user/1 - Hämtar alla kurser en användare är registrerad på
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var enrollments = await _enrollmentService.GetByUserIdAsync(userId);
            return Ok(enrollments);
        }

        // POST: api/enrollments - Registrerar en användare på en kurs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto dto)
        {
            var enrollment = await _enrollmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), enrollment);
        }

        // DELETE: api/enrollments/1 - Tar bort en registrering
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _enrollmentService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}