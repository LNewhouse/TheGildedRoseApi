using System;
using System.Collections.Generic;

namespace TheGildedRoseApi.Models
{
    /// <summary>
    /// Information needed to document a transaction
    /// </summary>
    public class Transaction
    {
        public int UserId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public string ItemName { get; set; }

        public DateTime TransactionTime { get; set; }
    }

    public static class TransactionHelperClass
    {
        /// <summary>
        /// Builds the Gilded Rose's sample transaction list
        /// </summary>
        /// <returns></returns>
        public static List<Transaction> GenerateTransactions()
        {
            var transactions = new List<Transaction>();

            transactions.Add(new Transaction { ItemId = 1, ItemName = "Freshly Baked Bread", Quantity = 5, UserId = 1, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-10) });

            transactions.Add(new Transaction { ItemId = 2, ItemName = "Rockscale Cod", Quantity = 2, UserId = 1, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-8) });

            transactions.Add(new Transaction { ItemId = 2, ItemName = "Rockscale Cod", Quantity = 1, UserId = 4, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-6) });

            transactions.Add(new Transaction { ItemId = 4, ItemName = "Tough Jerky", Quantity = 15, UserId = 2, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-4) });

            transactions.Add(new Transaction { ItemId = 6, ItemName = "Tropical Sunfruit", Quantity = 20, UserId = 2, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-2) });

            return transactions;
        }
    }
}