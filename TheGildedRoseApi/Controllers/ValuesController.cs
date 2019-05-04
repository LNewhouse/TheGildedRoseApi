using System.Collections.Generic;
using System.Linq;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Mvc;

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private List<Item> gildedRoseInventory = ItemHelperClass.BuildInventory();

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
