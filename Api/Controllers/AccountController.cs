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
using Api.Global;
using Api.Parameters;
using Api.Dtos.ExtendedDto;

namespace Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
            var enties = await _service.GetAll();
            return Ok(enties);
        }

        [HttpPost("login")]
        public async Task<ResponseObject> Login([FromBody] AccountDto dto)
        {
            var result = await _service.GetByEmail(dto.Email);
            if (result == null)
            {
                return new ResponseObject
                {
                    status = "error",
                    message = "Account is not found"
                };
            }
            return new ResponseObject
            {
                status = "success",
                data = result
            };
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ResponseObject> GetAccount(int id)
        {
            var account = await _service.GetById(id);

            if (account == null)
            {
                return new ResponseObject { data = null, status = "failed", message = "Account is not found" };
            }

            return new ResponseObject { data = account, status = "success", message = "Success" };
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update")]
        public async Task<ResponseObject> PutAccount([FromBody] AccountDto account)
        {
            try
            {
                await _service.Update(account);
                return new ResponseObject
                {
                    status = "success",
                    data = "",
                    message = ""
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject
                {
                    status = "error",
                    data = "",
                    message = "Account is not found"
                };

            }


        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add")]
        public async Task<ResponseObject> PostAccount([FromBody] AccountDto account)
        {
            try
            {
                await _service.Insert(account);
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



        private bool AccountExists(int id)
        {
            return _service.GetById(id) != null;
        }

        [HttpGet("search")]
        public async Task<ResponseObject> Search([FromQuery] AccountParameter param)
        {
            var entities = await _service.Search(param);
            return new ResponseObject
            {
                data = entities,
                message = "sucess",
                status = "success",
            };
        }
        [HttpGet("detail")]
        public async Task<ResponseObject> GetDetail(string email)
        {
            var entity = await _service.GetByEmail(email);
            if (entity == null)
            {
                return new ResponseObject
                {
                    data = "",
                    message = "Account is not found",
                    status = "failed",
                };
            }
            return new ResponseObject
            {
                data = entity,
                message = "sucess",
                status = "success",
            };
        }

        [HttpDelete("delete")]
        public async Task<ResponseObject> Delete(string email)
        {
            var result = await _service.UpdateStatus(email);
            if (result)
            {
                return new ResponseObject
                {
                    data = result,
                    status = "success"
                };
            }

            return new ResponseObject { status = "failed" };

        }
    }
}
