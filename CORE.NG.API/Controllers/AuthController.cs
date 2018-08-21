﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CORE.NG.DATA.DBModel;
using CORE.NG.MODELS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NG.CORE.BUSINESS;

namespace CORE.NG.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _authBL;

        private readonly IConfiguration _config;
        public AuthController(IAuthBL authBL, IConfiguration config)
        {
            _config = config;
            _authBL = authBL;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authBL.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _authBL.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {

            var userFromRepo = await _authBL.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[] {
                new Claim (ClaimTypes.NameIdentifier, userFromRepo.Id.ToString ()),
                new Claim (ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}