using Api.Dtos;
using Api.Global;
using Api.Parameters;
using Api.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/marks")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _service;

        public MarkController(IMarkService service)
        {
            _service = service;
        }
        [HttpGet("search")]
        public async Task<ResponseObject> Search([FromQuery]MarkParameter param)
        {
            var entities = await _service.Search(param);
            return new ResponseObject
            {
                data = entities,
                status = "success"
            };
        }
        [HttpGet("{id}")]
        public async Task<ResponseObject> GetById(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null)
            {
                return new ResponseObject
                {
                    status = "failed",
                    data = "",
                    message = "Mark id is not found"
                };
            }
            else
            {
                return new ResponseObject
                {
                    status = "success",
                    data = entity,
                };
            }
        }

        [HttpPost("add")]
        public async Task<ResponseObject> Insert([FromBody] MarkDto dto)
        {
            if (dto == null)
            {
                return new ResponseObject { status = "error",
                    message = "Parameter is not null"
                };
            }
            else
            {
                await _service.Insert(dto);
                return new ResponseObject
                {
                    status = "success"
                };
            }
        }

        [HttpPut("update")]
        public async Task<ResponseObject> Update([FromBody] MarkDto dto)
        {
            if (dto == null)
            {
                return new ResponseObject
                {
                    status = "error",
                    message = "Parameter is not null"
                };
            }
            else
            {
                var entity = await _service.GetById(dto.Id);
                if (entity == null)
                {
                    return new ResponseObject
                    {
                        status = "error",
                        message="Mark id is not found"
                    };
                }
                else
                {
                    await _service.Update(dto);
                    return new ResponseObject
                    {
                        status = "success"
                    };
                }
                
            }
        }

        [HttpGet("get-by-group")]
        public async Task<ResponseObject> GetByGroup(int groupId)
        {
            var entities = await _service.GetByGroup(groupId);
            return new ResponseObject
            {
                data = entities,
                status = "success"
            };
        }
    }
}
