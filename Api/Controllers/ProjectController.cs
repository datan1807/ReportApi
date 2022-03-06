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
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        // GET: api/Project
        [HttpGet("get-all")]
        public async Task<ResponseObject> GetProjects()
        {
            var entities = await _service.GetAll();
            return new ResponseObject
            {
                status = "success",
                data = entities
            };
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ResponseObject> GetProject(int id)
        {
            var project = await _service.GetById(id);

            if (project == null)
            {
                return new ResponseObject
                {
                    status = "error",
                    message = "Project is not found"
                };
            }

            return new ResponseObject
            {
                status = "success",
                data = project
            };
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<ResponseObject> PutProject(int id, ProjectDto project)
        {
            if (id != project.Id)
            {
                return new ResponseObject
                {
                    status = "error",
                    message ="Id is not matched"
                };
            }
            try
            {
                await _service.Update(project);
                return new ResponseObject
                {
                    status = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject
                {
                    status = "error",
                    message = ex.Message
                };
            }
        }

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add")]
        public async Task<ResponseObject> PostProject([FromBody]ProjectDto project)
        {
            try
            {
                await _service.Insert(project);
                return new ResponseObject
                {
                    status = "success"
                };
            }catch (Exception ex)
            {
                return new ResponseObject
                {
                    status = "error",
                    message = ex.Message
                };
            }          
        }

        [HttpGet("search")]
        public async Task<ResponseObject> Search([FromQuery]ProjectParameter param)
        {
            var enities = await _service.Search(param);
            return new ResponseObject
            {
                data = enities,
                status = "success"
            };
        }

        [HttpPut("inactive/{id}")]
        public async Task<ResponseObject> UpdateStatus(int id)
        {
            var enities = await _service.GetById(id);
            enities.Status = "Inactive";
            await _service.Update(enities);
            return new ResponseObject
            {
                status = "success"
            };
        }
    }
}
