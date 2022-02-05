using Api.Dtos;
using Api.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _service.GetAll();
            return Ok(roles);
        }
        [HttpPost]
        public async Task<ActionResult> Add(RoleDto role)
        {
            if(role == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    await _service.Insert(role);
                }catch(Exception ex)
                {
                    return BadRequest();
                }
                return NoContent();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(RoleDto role)
        {
            if(role != null)
            {
                await _service.Update(role);
                return NoContent();
            }
            return BadRequest();
        }
        [HttpGet("id")]
        public async Task<ActionResult> Get(int id)
        {
            var role = await _service.GetById(id);
            if(role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
    }
}
