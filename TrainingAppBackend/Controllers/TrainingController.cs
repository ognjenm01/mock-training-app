using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrainingAppBackend.DTO;
using TrainingAppBackend.Services;

namespace TrainingAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet("{id}")]
        [Authorize()]
        public async Task<ActionResult<TrainingDTO?>> GetById([FromRoute] int id)
        {
            return Ok(await _trainingService.GetById(id));
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<TrainingDTO?>>> GetAll()
        {
            return Ok(await _trainingService.GetAll());
        }

        [HttpGet("overview")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TrainingDTO?>>> GetByMonth(
            [FromQuery] int month,
            [FromQuery] int year)
        {
            var userId = User.Claims.ElementAt(1).Value;
            return Ok(await _trainingService.GetByMonthAndYear(month, year, Convert.ToInt32(userId)));
        }


        [HttpPost]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<TrainingDTO?>>> AddTraining([FromBody] TrainingDTO dto)
        {
            var userId = User.Claims.ElementAt(1).Value;
            dto.UserId = Convert.ToInt32(userId);
            return Ok(await _trainingService.AddTraining(dto));
        }
    }
}
