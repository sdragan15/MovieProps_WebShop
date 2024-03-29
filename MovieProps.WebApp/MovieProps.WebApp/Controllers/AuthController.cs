﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieProps.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService, IAuthService auth)
        {
            _configuration = configuration;
            _userService = userService;
            _authService = auth;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginDataIn dataIn)
        {
            var user = (await _userService.GetByEmail(dataIn.Email)).Data;

            if(user == null)
            {
                return Unauthorized();
            }

            if(user.Email.Equals(dataIn.Email) && user.Password.Equals(_authService.Encrypt(dataIn.Password)))
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var signingCredentials = new SigningCredentials(
                                        new SymmetricSecurityKey(key),
                                        SecurityAlgorithms.HmacSha512Signature);

                var subject = new ClaimsIdentity(new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                });

                
                var principal = new ClaimsPrincipal(subject);

                var expires = DateTime.Now.AddMinutes(100);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                HttpContext.User = principal;

                return Ok(jwtToken);
            }

            return Unauthorized();
            
        }

        [HttpPost("loginFacebook")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithFacebook([FromBody] LoginDataIn dataIn)
        {
            string token = dataIn.Token;
            var response = await _authService.LoginWithFacebook(token);
            var user = response.Data;

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var signingCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha512Signature);

            var subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                });


            var principal = new ClaimsPrincipal(subject);

            var expires = DateTime.Now.AddMinutes(100);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = expires,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(newToken);
            HttpContext.User = principal;

            return Ok(jwtToken);
        }
    }
}
