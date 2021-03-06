﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody] UserLogin login)
        {
            IActionResult response = Unauthorized();
            var user = UserAuthentication.Authenticate(login);

            if (user != null)
            {
                var tokenString = UserAuthentication.BuildToken(user);
                response = Ok(new {token = tokenString});
            }

            return response;
        }
    }
}