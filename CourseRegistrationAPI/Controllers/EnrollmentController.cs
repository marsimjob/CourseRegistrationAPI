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
            try
            {
                var enrollments = await _enrollmentService.GetAllAsync();
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/enrollments/user/1 - Hämtar alla kurser en användare är registrerad på
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var enrollments = await _enrollmentService.GetByUserIdAsync(userId);
                return Ok(enrollments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/enrollments - Registrerar en användare på en kurs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto dto)
        {
            try
            {
                var enrollment = await _enrollmentService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetAll), enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // DELETE: api/enrollments/1 - Tar bort en registrering
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _enrollmentService.DeleteAsync(id);
                if (!result) return NotFound(new { error = $"Registrering med id {id} hittades inte" });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}