using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheGildedRoseApi.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public int AccountID { get; set; }

        public string UserName { get; set; }

        public string ItemName { get; set; }

        public int TransactionCost { get; set; }
    }

    public class TransactionHelperClass
    {
        public static List<Transaction> BuildTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            transactions.Add(new Transaction {AccountID = 1, TransactionId = 1, UserName = "ValeeraSanguinar", ItemName = "Freshly Baked Bread", TransactionCost = 5});
            transactions.Add(new Transaction {AccountID = 1, TransactionId = 2, UserName = "ValeeraSanguinar", ItemName = "Tropical Sunfruit", TransactionCost = 30});
            transactions.Add(new Transaction {AccountID = 3, TransactionId = 3, UserName = "Thrall", ItemName = "Delicious Cave Mold", TransactionCost = 2});
            transactions.Add(new Transaction {AccountID = 3, TransactionId = 4, UserName = "Thrall", ItemName = "Sour Goat Cheese", TransactionCost = 15});
            transactions.Add(new Transaction {AccountID = 2, TransactionId = 5, UserName = "UtherLightBringer", ItemName = "Tough Jerky", TransactionCost = 5});

            return transactions;
        }
    }
}
