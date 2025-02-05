using Microsoft.AspNetCore.Mvc;
using TrainingAppBackend.Models;
using TrainingAppBackend.Services;

namespace TrainingAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User user)
        {
            if(user == null)
                //TODO Do better
                return BadRequest("Invalid user data");

            await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }
    }
}
