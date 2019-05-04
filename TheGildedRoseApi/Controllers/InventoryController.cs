using System.Collections.Generic;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Mvc;

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly List<Item> _gildedRoseInventory = ItemExtensions.BuildSampleInventory();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _gildedRoseInventory;
        }
    }
}
