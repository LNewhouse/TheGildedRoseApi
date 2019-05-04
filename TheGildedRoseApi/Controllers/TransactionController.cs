using System.Collections.Generic;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Mvc;
using TheGildedRoseApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private List<User> _users = UserExtensions.GenerateSampleUsers();
        private List<Transaction> _transactions = TransactionExtensions.GenerateSampleTransactions();
        private readonly List<Item> _gildedRoseInventory = ItemExtensions.BuildSampleInventory();

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string username, string password)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
