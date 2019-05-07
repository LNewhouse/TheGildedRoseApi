using System.Collections.Generic;

namespace GildedRoseAPITest.Models
{
    /// <summary>
    /// Information needed to document an item
    /// </summary>
    public class Item
    {
        #region Properties

        public string Description { get; set; }

        public int ItemId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        #endregion
    }

    public static class ItemExtensions
    {
        #region Public Methods

        /// <summary>
        /// Builds the Gilded Rose's sample inventory
        /// </summary>
        /// <returns></returns>
        public static List<Item> BuildSampleInventory()
        {
            List<Item> inventory = new List<Item>();

            inventory.Add(new Item { Name = "Freshly Baked Bread", Description = "Fresh out the oven", Price = 5, ItemId = 1 });

            inventory.Add(new Item { Name = "Rockscale Cod", Description = "Fresh from the stream", Price = 25, ItemId = 2 });

            inventory.Add(new Item { Name = "Delicious Cave Mold", Description = "Fresh from the cave", Price = 2, ItemId = 3 });

            inventory.Add(new Item { Name = "Tough Jerky", Description = "A weary traveler's best friend", Price = 5, ItemId = 4 });

            inventory.Add(new Item { Name = "Sour Goat Cheese", Description = "Fresh from the... well fresh... I think", Price = 15, ItemId = 5 });

            inventory.Add(new Item { Name = "Tropical Sunfruit", Description = "A staple of South Island Iced Tea", Price = 30, ItemId = 6 });

            return inventory;
        }

        #endregion
    }
}