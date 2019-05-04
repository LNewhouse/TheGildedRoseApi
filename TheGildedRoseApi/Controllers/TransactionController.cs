using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Mvc;
using TheGildedRoseApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private List<User> _users = UserExtensions.GenerateSampleUsers();
        private List<Transaction> _transactions = TransactionExtensions.GenerateSampleTransactions();
        private List<Item> _inventory = ItemExtensions.BuildSampleInventory();

        public TransactionController()
        {
            Users = _users;
            Transactions = _transactions;
            Inventory = _inventory;
        }

        // POST api/<controller>
        [HttpPost("{purchaseOrder}")]
        public HttpStatusCode Post([FromBody]PurchaseOrder purchaseOrder)
        {
            Transaction transaction = new Transaction
            {
                PurchaseOrder = purchaseOrder,
                TransactionTime = DateTime.Now.ToUniversalTime(),
                UserId = 1 //TODO Authenticated user here
            };

            // Grab user that is associated with the transaction
            User transactionUser = Users.First(u => u.UserId == transaction.UserId);

            // Grab the item price that is associated with the purchase item
            int itemPrice = Inventory.First(i => i.ItemId == purchaseOrder.ItemId).Price;

            // Validate transaction
            bool isValidTransaction = TransactionExtensions.ValidateTransaction(transaction, transactionUser.AccountBalance, itemPrice);

            if (isValidTransaction)
            {
                // Decrement account balance in DB
                transactionUser.AccountBalance = (transactionUser.AccountBalance - (transaction.PurchaseOrder.Quantity * itemPrice));

                // Add transaction in DB
                Transactions.Add(transaction);

                // Return successful response
                return HttpStatusCode.Accepted;
            }

            // Return failed response
            return HttpStatusCode.Forbidden;
        }

        private List<User> Users { get;}

        private List<Transaction> Transactions { get;}

        private List<Item> Inventory { get; }
    }
}
