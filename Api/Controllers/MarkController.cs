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
        public async Task<ResponseObject> Search([FromQuery] MarkParameter param)
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
            try
            {
                await _service.Insert(dto);
                return new ResponseObject
                {
                    status = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject
                {
                    status = "error"
                };
            }
        }

        [HttpPut("update")]
        public async Task<ResponseObject> Update([FromBody] MarkDto dto)
        {
            try
            {
                await _service.Update(dto);
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

        [HttpGet("get-by-group")]
        public async Task<ResponseObject> GetByGroup(int groupId, int isClosed, int roleId)
        {
            var close = false;
            if(isClosed > 0)
            {
                close = true;
            }
            var entities = await _service.GetByGroup(groupId, close,  roleId);
            return new ResponseObject
            {
                data = entities,
                status = "success"
            };
        }
        [HttpPost("submit-mark")]
        public async Task<ResponseObject> GetByAccount([FromBody] List<MarkDto> listMarks)
        {
            try {
            await _service.SubmitMark(listMarks);
                return new ResponseObject { status = "success" };
            } catch(Exception ex)
            {
                return new ResponseObject { status = "error" };
            }
           
            
        }
    }
}
