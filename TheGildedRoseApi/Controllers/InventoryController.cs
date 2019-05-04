using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private List<Item> inventory = ItemHelperclass.BuildInventory();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return inventory;
        }
    }
}
