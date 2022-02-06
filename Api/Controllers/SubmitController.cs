#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Api.Services.IService;
using Api.Dtos;

namespace Api.Controllers
{
    [Route("api/submits")]
    [ApiController]
    public class SubmitsController : ControllerBase
    {
        private readonly ISubmitService _service;

        public SubmitsController(ISubmitService service)
        {
            _service = service;
        }

        // GET: api/Submits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubmitDto>>> GetSubmits()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/Submits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubmitDto>> GetSubmit(int id)
        {
            var submit = await _service.GetById(id);

            if (submit == null)
            {
                return NotFound();
            }

            return Ok(submit);
        }

        // PUT: api/Submits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubmit(int id, SubmitDto submit)
        {
            if (id != submit.Id)
            {
                return BadRequest();
            }

            await _service.Update(submit);

            return NoContent();
        }

        // POST: api/Submits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostSubmit(SubmitDto submit)
        {
            await _service.Insert(submit);
            return NoContent();
        }

        // DELETE: api/Submits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmit(int id)
        {
            

            return NoContent();
        }

    }
}
