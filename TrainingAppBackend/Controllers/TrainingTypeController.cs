using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;
using TrainingAppBackend.Services;

namespace TrainingAppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingTypeController : ControllerBase
    {
        private readonly ITrainingTypeService _trainingTypeService;

        public TrainingTypeController(ITrainingTypeService trainingTypeService)
        {
            _trainingTypeService = trainingTypeService;
        }

        [HttpGet("{id}")]
        [Authorize()]
        public async Task<ActionResult<TrainingTypeDTO?>> GetById([FromRoute] int id) 
        {
            return Ok(await _trainingTypeService.GetById(id));
        }

        [HttpGet]
        [Authorize()]
        public async Task<ActionResult<IEnumerable<TrainingTypeDTO?>>> GetAll()
        {
            return Ok(await _trainingTypeService.GetAll());
        }
    }
}
