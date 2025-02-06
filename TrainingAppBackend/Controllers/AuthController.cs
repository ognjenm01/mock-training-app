using Microsoft.AspNetCore.Mvc;
using TrainingAppBackend.DTO;
using TrainingAppBackend.Services;

namespace TrainingAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<JwtDTO?>> Login([FromBody] LoginRequestDTO request)
        {
            var token = await _authService.Login(request);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);
        }

        [HttpPost("/register")]
        public async Task<ActionResult<JwtDTO?>> Register([FromBody] RegisterRequestDTO request)
        {
            JwtDTO? jwt =  await _authService.Register(request);
            if (jwt == null)
                return Conflict(jwt);
            else
                return Ok(jwt);
        }
    }
}
