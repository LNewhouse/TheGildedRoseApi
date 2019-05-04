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

        public DateTime TransactionTime { get; set; }
    }

    public static class TransactionExtensions
    {
        /// <summary>
        /// Validates the given transactions
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static bool ValidateTransaction(Transaction transaction)
        {
            bool isValid = true;

            if (transaction.UserId < 0 || transaction.UserId == 0)
            {
                return false;
            }

            if (transaction.ItemId < 0 || transaction.ItemId == 0)
            {
                return false;
            }

            if (transaction.Quantity < 0 || transaction.Quantity == 0)
            {
                return false;
            }

            return isValid;
        }

        /// <summary>
        /// Builds the Gilded Rose's sample transaction list
        /// </summary>
        /// <returns></returns>
        public static List<Transaction> GenerateSampleTransactions()
        {
            var transactions = new List<Transaction>();

            transactions.Add(new Transaction { ItemId = 1, Quantity = 5, UserId = 1, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-10) }); //Freshly Baked Bread

            transactions.Add(new Transaction { ItemId = 2, Quantity = 2, UserId = 1, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-8) }); //Rockscale Cod

            transactions.Add(new Transaction { ItemId = 2, Quantity = 1, UserId = 4, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-6) }); //Rockscale Cod

            transactions.Add(new Transaction { ItemId = 4, Quantity = 15, UserId = 2, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-4) }); //Tough Jerky

            transactions.Add(new Transaction { ItemId = 6, Quantity = 20, UserId = 2, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-2) }); //Tropical Sunfruit

            return transactions;
        }
    }
}