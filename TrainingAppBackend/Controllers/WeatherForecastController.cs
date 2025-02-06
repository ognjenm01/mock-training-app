using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingAppBackend.Models;
using TrainingAppBackend.Services;

namespace TrainingAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [Authorize()]
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            var forecasts = await _service.GetAllAsync();

            if(forecasts == null || !forecasts.Any()) 
                return NotFound();

            return Ok(forecasts);
        }
    }
}
