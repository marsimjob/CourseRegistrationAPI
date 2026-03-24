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
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        // GET: api/courses/1 - Hämtar en specifik kurs
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // POST: api/courses - Skapar en ny kurs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
        {
            var course = await _courseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        // PUT: api/courses/1 - Uppdaterar en befintlig kurs
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCourseDto dto)
        {
            var course = await _courseService.UpdateAsync(id, dto);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // DELETE: api/courses/1 - Tar bort en kurs
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}