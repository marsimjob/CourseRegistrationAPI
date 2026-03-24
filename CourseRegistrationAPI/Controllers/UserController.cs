using CourseRegistrationAPI.DTOs;
using CourseRegistrationAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        // Injicerar UserService via konstruktorn
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users - Hämtar alla användare
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET: api/users/1 - Hämtar en specifik användare
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/users - Skapar en ny användare
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var user = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/users/1 - Uppdaterar en befintlig användare
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUserDto dto)
        {
            var user = await _userService.UpdateAsync(id, dto);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // DELETE: api/users/1 - Tar bort en användare
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}