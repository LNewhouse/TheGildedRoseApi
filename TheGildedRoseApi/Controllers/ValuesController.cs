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
    public class ValuesController : ControllerBase
    {
        private List<Item> gildedRoseInventory = ItemHelperclass.BuildInventory();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return gildedRoseInventory;
        }

        // GET api/<controller>/itemName
        [HttpGet("{itemName}")]
        public ActionResult<Item> Get(string itemName)
        {
            if (gildedRoseInventory.Any(i => i.Name.ToUpper() == itemName.ToUpper()))
            {
                return gildedRoseInventory.First(i => i.Name.ToUpper() == itemName.ToUpper());
            }

            return NotFound($"Item not found: {itemName}");
        }
    }
}
