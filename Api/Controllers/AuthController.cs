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
using Api.Global;
using Api.Dtos.ExtendedDto;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IConfiguration _configuration;

        public AuthController(IAccountService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<ResponseObject> AuthToken([FromBody] AuthRequest request)
        {
            ResponseObject response = new ResponseObject
            {
                status = "error"
            };
            AuthResponse auth = new AuthResponse();
            var entity = await _service.GetByEmail(request.Email);
            var token = string.Empty;
            if (entity != null)
            {
                token = CreateToken(entity);
                auth.Token = token;
                auth.Account = entity;
                response.status = "success";
                response.data = auth;
            }
            return response;
        }

        private string CreateToken(ExtendedAccountDto dto)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", dto.Id.ToString()),
                new Claim("email", dto.Email),
                new Claim("role", dto.RoleName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSetting:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.UtcNow.AddSeconds(60)
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
