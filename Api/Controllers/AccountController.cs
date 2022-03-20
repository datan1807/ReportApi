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
        public async Task<ResponseObject> Delete(int id)
        {
            var result = await _service.UpdateStatus(id);
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

        [HttpGet("get-by-group/{groupCode}")]
        public async Task<ResponseObject> GetByGroup(string groupCode)
        {
            var entities = await _service.GetAccountByGroup(groupCode);
            return new ResponseObject
            {
                status = "success",
                data = entities
            };
        }

        [HttpGet("get-by-role")]
        public async Task<ResponseObject> GetByRole(int role)
        {
            var entities = await _service.GetByRole(role);
            return new ResponseObject
            {
                data = entities,
                status = Constants.STATUS.SUCCESS
            };
        }

        [HttpGet("get-by-code")]
        public async Task<ResponseObject> GetByCode(string code, int role)
        {
            var entities = await _service.GetByCode(code, role);
            return new ResponseObject
            {
                data = entities,
                status = Constants.STATUS.SUCCESS
            };
        }

        [HttpGet("check-mail-exist")]
        public async Task<ResponseObject> CheckMail([FromQuery]string email)
        {
            return new ResponseObject
            {
                data = await _service.CheckEmail(email),
                status = Constants.STATUS.SUCCESS
            };
        }

        [HttpGet("check-code-exist")]
        public async Task<ResponseObject> CheckCode([FromQuery] string accountCode)
        {
            return new ResponseObject
            {
                data = await _service.CheckCode(accountCode),
                status = Constants.STATUS.SUCCESS
            };
        }
        [HttpGet("get-available-member")]
        public async Task<ResponseObject> GetAvailableMember([FromQuery]MemberParameter parameter)
        {
            return new ResponseObject
            {
                data = await _service.GetMember(parameter),
                status = Constants.STATUS.SUCCESS
            };
        }
    }
}
