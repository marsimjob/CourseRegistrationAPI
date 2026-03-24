using CourseRegistrationAPI.DTOs;
using CourseRegistrationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        // Injicerar CourseService via konstruktorn
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/courses - Hämtar alla kurser
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courses = await _courseService.GetAllAsync();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // GET: api/courses/1 - Hämtar en specifik kurs
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var course = await _courseService.GetByIdAsync(id);
                if (course == null) return NotFound(new { error = $"Kurs med id {id} hittades inte" });
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // POST: api/courses - Skapar en ny kurs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
        {
            try
            {
                var course = await _courseService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // PUT: api/courses/1 - Uppdaterar en befintlig kurs
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCourseDto dto)
        {
            try
            {
                var course = await _courseService.UpdateAsync(id, dto);
                if (course == null) return NotFound(new { error = $"Kurs med id {id} hittades inte" });
                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // DELETE: api/courses/1 - Tar bort en kurs
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _courseService.DeleteAsync(id);
                if (!result) return NotFound(new { error = $"Kurs med id {id} hittades inte" });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}