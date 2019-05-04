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

        public PurchaseOrder PurchaseOrder { get; set; }

        public DateTime TransactionTime { get; set; }
    }

    public static class TransactionExtensions
    {
        /// <summary>
        /// Validates the given transactions
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="accountBalance"></param>
        /// <returns></returns>
        public static bool ValidateTransaction(Transaction transaction, int accountBalance, int itemPrice)
        {
            bool isValid = true;

            if (transaction.UserId < 0 || transaction.UserId == 0)
            {
                return false;
            }

            if (transaction.PurchaseOrder.ItemId < 0 || transaction.PurchaseOrder.ItemId == 0)
            {
                return false;
            }

            if (transaction.PurchaseOrder.Quantity < 0 || transaction.PurchaseOrder.Quantity == 0)
            {
                return false;
            }

            if (accountBalance - (transaction.PurchaseOrder.Quantity * itemPrice) < 0)
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

            transactions.Add(new Transaction { PurchaseOrder = new PurchaseOrder {ItemId = 1, Quantity = 5}, UserId = 1, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-10) }); //Freshly Baked Bread

            transactions.Add(new Transaction { PurchaseOrder = new PurchaseOrder { ItemId = 2, Quantity = 2}, UserId = 1, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-8) }); //Rockscale Cod

            transactions.Add(new Transaction { PurchaseOrder = new PurchaseOrder { ItemId = 2, Quantity = 1}, UserId = 4, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-6) }); //Rockscale Cod

            transactions.Add(new Transaction { PurchaseOrder = new PurchaseOrder { ItemId = 4, Quantity = 15}, UserId = 2, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-4) }); //Tough Jerky

            transactions.Add(new Transaction { PurchaseOrder = new PurchaseOrder { ItemId = 6, Quantity = 20}, UserId = 2, TransactionTime = DateTime.Now.ToUniversalTime().AddDays(-2) }); //Tropical Sunfruit

            return transactions;
        }
    }
}