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
using Api.Parameters;

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
                    status = "failed",
                    message = "Submit is not found!"
                };
            }

            return new ResponseObject
            {
                data = submit,
                status ="success"
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
                    status = "failed",
                    message = "Submit is not found!"
                };
            }

            try {
                await _service.Update(submit);

                return new ResponseObject { status = "success" };
            } catch
            {
                return new ResponseObject { status = "false" };
            }
        }

        // POST: api/Submits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseObject> PostSubmit([FromBody] SubmitDto submit)
        {       
            try
            {
                await _service.Insert(submit);
                return new ResponseObject { status="success" };
            }catch (Exception ex)
            {
                return new ResponseObject { status = "failed" };
            }
        }
        [HttpGet("get-by-report-and-project")]
        public async Task<ResponseObject> GetByReportAndProject(int reportId, int groupId)
        {
            if(reportId <0 && groupId < 0)
            {
                return new ResponseObject
                {
                    status = "failed",
                    message = "Param is not null"
                };
            }
            var entity = await _service.GetByReportAndGroup(reportId, groupId);
            return new ResponseObject
            {
                data = entity,
                status = "success"
            };

        }

        [HttpGet("search")]
        public async Task<ResponseObject> Search([FromQuery]SubmitParameter param)
        {
            var entities = await _service.Search(param);
            return new ResponseObject
            {
                data = entities,
                status = "success"
            };
        }
    }
}
