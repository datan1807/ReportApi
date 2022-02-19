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
        public async Task<ActionResult> Login(string email, string password)
        {
            var result = await _service.CheckLogin(email, password);
            if(result == null)
            {
                return Ok("failed");
            }
            return Ok(result);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ResponseObject> GetAccount(string id)
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
        public async Task<ResponseObject> PutAccount(string id, AccountDto account)
        {
            if (id != account.Email)
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
                if (!AccountExists(id))
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

       

        private bool AccountExists(string id)
        {
            return _service.GetById(id) != null;
        }
        [HttpGet("role")]
        public async Task<ActionResult<ResponseData<ExtendedAccountDto>>> GetAccount([FromQuery]AccountParameter param){
            var result = await _service.GetByRole(param);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
