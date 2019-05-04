using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRoseAPITest.Models
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }

    public static class ItemHelperclass
    {
        /// <summary>
        /// Builds the Gilded Rose's sample inventory;
        /// </summary>
        /// <returns></returns>
        public static List<Item> BuildInventory()
        {
            List<Item> inventory = new List<Item>();

            inventory.Add(new Item { Name = "Freshly Baked Bread", Description = "Fresh out the oven", Price = 5 });

            inventory.Add(new Item { Name = "Rockscale Cod", Description = "Fresh from the stream", Price = 25 });

            inventory.Add(new Item { Name = "Delicious Cave Mold", Description = "Fresh from the cave", Price = 2 });

            inventory.Add(new Item { Name = "Tough Jerky", Description = "A weary traveler's best friend", Price = 5 });

            inventory.Add(new Item { Name = "Sour Goat Cheese", Description = "Fresh from the... well fresh... I think", Price = 15 });

            inventory.Add(new Item { Name = "Tropical Sunfruit", Description = "A staple of South Island Iced Tea", Price = 30 });

            return inventory;
        }
    }
}