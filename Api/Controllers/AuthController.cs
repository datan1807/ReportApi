#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Services.IService;
using Api.Global;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _service;

        public AuthController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("/login")]
        public async Task<ResponseObject> Login([FromBody]string email)
        {
            var entity =await _service.GetByEmail(email);
            if(entity == null)
            {
                return new ResponseObject
                {
                    data = "",
                    message = "Account is not existed",
                    status = "failed"
                };
            }
            return new ResponseObject
            {
                data = entity,
                message = "Login successfully",
                status = "success"
            };
        }
    }
}
