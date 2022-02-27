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
using Api.Global;

namespace Api.Controllers
{
    [Route("api/submits")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        private readonly ISubmitService _service;

        public SubmitController(ISubmitService service)
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
        public async Task<ResponseObject> GetSubmit(int id)
        {
            var submit = await _service.GetById(id);

            if (submit == null)
            {
                return new ResponseObject
                {
                    status = "NotFound"
                };
            }

            return new ResponseObject
            {
                data = submit,
                status = "success"
            };
        }

        // PUT: api/Submits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseObject> PutSubmit(int id, SubmitDto submit)
        {
            if (id != submit.Id)
            {
                return new ResponseObject
                {
                    status = "NotFound"
                };
            }

            await _service.Update(submit);

            return new ResponseObject { status = "success" };
        }

        // POST: api/Submits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostSubmit(SubmitDto submit)
        {
            await _service.Insert(submit);
            return NoContent();
        }
        [HttpGet("get-by-report-and-project")]
        public async Task<ResponseObject> GetByReportAndProject(int reportId, int projectId)
        {
            if(reportId <=0 && projectId <= 0)
            {
                throw new ArgumentException();
            }
            var entity = await _service.GetByProjectAndReport(reportId, projectId);
            return new ResponseObject
            {
                data = entity,
                status = "success"
            };

        }
    }
}
