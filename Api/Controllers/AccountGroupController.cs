#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Services.IService;
using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;

namespace Api.Controllers
{
    [Route("api/account-group")]
    [ApiController]
    public class AccountGroupController : ControllerBase
    {
        private readonly IAccountGroupService _service;

        public AccountGroupController(IAccountGroupService service)
        {
            _service = service;
        }

        // GET: api/AccountGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountGroupDto>>> GetAccountGroups()
        {
            var entities = await _service.GetAll();
            return Ok(entities);
        }

        // GET: api/AccountGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountGroupDto>> GetAccountGroup(int id)
        {
            var entity = await _service.GetById(id);
            if (entity == null)
            {
                return NoContent();
            }
            return Ok(entity);
        }

        // PUT: api/AccountGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountGroup(int id, [FromBody] AccountGroupDto accountGroup)
        {
            if (id != accountGroup.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(accountGroup);
            }
            catch (DbUpdateConcurrencyException)
            {
                var entity = await _service.GetById(id);
                if (entity == null)
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/AccountGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseObject> PostAccountGroup(ExtendedAccountGroupDto dto)
        {
            bool exist = await _service.CheckStudentExist(dto);
            if (exist)
            {
                return new ResponseObject
                {
                    status = "error",
                    message = "Student is register group in this semester"
                };
            }
            AccountGroupDto accountGroupDto = new AccountGroupDto
            {
                AccountId = dto.AccountId,
                GroupId = dto.GroupId
            };
            await _service.Insert(accountGroupDto);
            return new ResponseObject
            {
                status = "success"
            };
        }
        [HttpGet("find-by-group-id")]
        public async Task<ActionResult<IEnumerable<ExtendedAccountGroupDto>>> GetByGroupId([FromQuery] int groupId)
        {
            var entities = await _service.FindByGroupId(groupId);
            return Ok(entities);
        }
      
    }
}
