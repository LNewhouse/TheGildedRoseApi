using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TheGildedRoseApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGildedRoseApi.Controllers
{
    /// <summary>
    /// API for logging a user in and assigning them a JWT
    /// </summary>
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly List<User> _registeredUsers = UserExtensions.GenerateSampleUsers();

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] UserLogin login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new {token = tokenString});
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:256KeyBitKeyForTestingPurposes"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("Jwt:Issuer",
                "Jwt:Issuer",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin login)
        {
            User user = null;

            if (_registeredUsers.Any(u => u.UserLogin.Username == login.Username) &&
                _registeredUsers.Any(u => u.UserLogin.Password == login.Password))
            {
                user = _registeredUsers.First(ru => ru.UserLogin.Username == login.Username);
            }

            return user;
        }
    }
}