#nullable disable
using Api.Dtos;
using Api.Services.IService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/council-evaluations")]
    [ApiController]
    public class CouncilEvaluationCotroller : ControllerBase
    {
        private readonly ICouncilEvaluationService _service;

        public CouncilEvaluationCotroller(ICouncilEvaluationService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouncilEvaluationDto>>> GetAll()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody]CouncilEvaluationDto entity)
        {
            await _service.Insert(entity);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, CouncilEvaluationDto entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _service.Update(entity);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var entities = await _service.GetById(id);
            if(entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }
    }
}
