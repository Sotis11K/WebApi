﻿using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ApiContexts context, IConfiguration configuration) : ControllerBase
    {
        private readonly ApiContexts _context = context;
        private readonly IConfiguration _configuration = configuration;


        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register(UserRegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                if(!await _context.Users.AnyAsync(x => x.Email == form.Email))
                {
                    _context.Users.Add(UserFactory.Create(form));
                    await _context.SaveChangesAsync();
                    return Created("", null);
                }

                return Conflict();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(UserLoginForm form)
        {
            if (ModelState.IsValid)
            {
                var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == form.Email);
                if (userEntity != null && PasswordHasher.ValidateSecurePassword(form.Password, userEntity.Password))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                            new(ClaimTypes.Email, userEntity.Email),
                            new(ClaimTypes.Name, userEntity.Email),
                            new(ClaimTypes.Role, "User")


                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"],
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new {Token = tokenString});
                }
            }

            return Unauthorized();
        }


    }
}
