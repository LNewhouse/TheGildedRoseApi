using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheGildedRoseApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class UserLoginController : Controller
    {
        private List<User> registeredUsers = UserExtensions.GenerateUsers();

        // Post: api/<controller>/UserLogin/
        [HttpPost]
        public IEnumerable<User> Post(string userName, string password)
        {
            return registeredUsers;
        }

        // GET api/<controller>/accountId
        [HttpGet("{userId}")]
        public User Delete(int userId)
        {
            return registeredUsers.First(t => t.UserId == userId);
        }
    }
}
