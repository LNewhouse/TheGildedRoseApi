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
    public class UsersController : Controller
    {
        private List<User> registeredUsers = UserExtensions.GenerateUsers();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return registeredUsers;
        }

        // GET api/<controller>/5
        [HttpGet("{accountID}")]
        public User Get(int accountID)
        {
            return registeredUsers.First(t => t.UserId == accountID);
        }
    }
}
