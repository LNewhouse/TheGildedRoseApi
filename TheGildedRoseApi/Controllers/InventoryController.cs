﻿using System.Collections.Generic;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheGildedRoseApi.Controllers
{
    /// <summary>
    /// API for receiving the inventory list
    /// </summary>
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        #region Attributes

        private readonly List<Item> _gildedRoseInventory = ItemExtensions.BuildSampleInventory();

        #endregion


        #region Public Methods

        // GET: api/<controller>
        [HttpGet, AllowAnonymous]
        public IEnumerable<Item> Get()
        {
            // Return all inventory items
            return _gildedRoseInventory;
        }

        #endregion
    }
}
