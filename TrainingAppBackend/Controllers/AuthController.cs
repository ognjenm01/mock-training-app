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
        public async Task<ActionResult<String?>> Login([FromBody] LoginRequestDTO request)
        {
            String? token = await _authService.Login(request);
            if (token == null)
            {
                return NotFound();
            }

            return Ok(token);
        }

        [HttpPost("/register")]
        public async Task<ActionResult<String?>> Register([FromBody] RegisterRequestDTO request)
        {
            return await _authService.Register(request);
        }
    }
}
