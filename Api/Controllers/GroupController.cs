#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Parameters;
using Api.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            this._service = service;
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ResponseObject> GetGroup(int id)
        {
            var @group = await _service.GetByGroupId(@id);

            if (@group == null)
            {
                return new ResponseObject { status = "error" };
            }

            return new ResponseObject
            {
                data = @group,
                status = "success"
            };
        }

        // PUT: api/Group/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseObject> PutGroup(int id, GroupDto @group)
        {
            if (id != @group.Id)
            {
                return new ResponseObject() { status = "error" };
            }
            try
            {
                await _service.Update(@group);
                return new ResponseObject() { status = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseObject { status = "error" };
            }
        }

        // POST: api/Group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseObject> PostGroup([FromBody] GroupDto @group)
        {
            try
            {
                await _service.Insert(@group);
                return new ResponseObject() { status = "success" };
            }
            catch (Exception ex)
            {
                return new ResponseObject { status = "error" };
            }
        }

        [HttpGet("get-by-account")]
        public async Task<ResponseObject> FindByAccount(string email)
        {
            var entities = await _service.GetGroupByAccount(email);
            ResponseObject response = new ResponseObject();
            response.data = entities;
            return response;
        }

        [HttpGet("search")]
        public async Task<ResponseObject> Search([FromQuery] GroupParameter param)
        {
            var entities = await _service.Search(param);
            ResponseObject response = new ResponseObject();
            response.data = entities;
            return response;
        }

        [HttpGet("check-exist")]
        public async Task<IActionResult> CheckExist([FromQuery] string groupCode)
        {
            bool result = false;
            result = await _service.CheckCodeExist(groupCode);
            return Ok(result);
        }

        [HttpPost("insert")]
        public async Task<ResponseObject> InsertGroup([FromBody] ExtendedGroupInsertDto dto)
        {
            if (dto == null)
            {
                return new ResponseObject
                {
                    status = "error",
                };
            }
            else
            {
                try
                {
                    bool result = await _service.InsertGroup(dto);
                    if (result)
                    {
                        return new ResponseObject
                        {
                            status = Constants.STATUS.SUCCESS,
                        };
                    }
                    else return  new ResponseObject
                    {
                        status = "error",
                    };
                }
                catch (Exception ex)
                {
                    return new ResponseObject
                    {
                        status = "error",
                    };
                }
            }
        }
    }
}
