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
        public async Task<ActionResult> Login([FromBody]AccountDto account)
        {
            var result = await _service.CheckLogin(account.Email, account.Password);
            if(result == null)
            {
                return Ok(null);
            }
            return Ok(result);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(string id)
        {
            var account = await _service.GetById(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(string id, AccountDto account)
        {
            if (id != account.Email)
            {
                return BadRequest();
            }



            try
            {
                await _service.Update(account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
