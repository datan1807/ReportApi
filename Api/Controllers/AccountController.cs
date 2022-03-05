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
        public async Task<ActionResult> Login([FromBody] AccountDto dto)
        {
            var result = await _service.CheckLogin(dto.Email, dto.Password);
            if(result == null)
            {
                return Ok("failed");
            }
            return Ok(result);
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

            return new ResponseObject { data = account, status = "success", message = "Success"};
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseObject> PutAccount(string email, AccountDto account)
        {
            if (email != account.Email)
            {
                return new ResponseObject
                {
                    status = "failed",
                    data = "",
                    message = "Account is not found"
                };
            }
            try
            {
                await _service.Update(account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(email))
                {
                    return new ResponseObject
                    {
                        status = "failed",
                        data = "",
                        message = "Account is not found"
                    };
                }
                else
                {
                    throw;
                }
            }

            return new ResponseObject
            {
                status = "success",
                data = "",
                message = ""
            };
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountDto>> PostAccount([FromBody]AccountDto account)
        {

                await _service.Insert(account);
            return NoContent();
           
        }

       

        private bool AccountExists(string email)
        {
            return _service.GetById(email) != null;
        }
       
        [HttpGet("search")]
        public async Task<ResponseObject> Search ([FromQuery]AccountParameter param)
        {
            var entities = await _service.Search(param);
            return new ResponseObject
            {
                data = entities,
                message = "sucess",
                status = "success",
            };
        }
        [HttpGet("detail/{email}")]
        public async Task<ResponseObject> GetDetail(string email)
        {
            var entity = await _service.GetByEmail(email);
            if(entity == null)
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

        [HttpDelete("delete/{email}")]
        public async Task<ResponseObject> Delete(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }
           
                var result = await _service.UpdateStatus(email);
                if (result)
                {
                    return new ResponseObject { data = result,
                    status = "success"};
                }
           
                return new ResponseObject { status = "failed" };
            
        }
    }
}
