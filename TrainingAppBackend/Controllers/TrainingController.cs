using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<TrainingDTO?>>> AddTraining([FromBody] TrainingDTO dto)
        {
            return Ok(await _trainingService.AddTraining(dto));
        }
    }
}
