using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using GildedRoseAPITest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheGildedRoseApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheGildedRoseApi.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        #region Attributes

        private List<User> _users = UserExtensions.GenerateSampleUsers();
        private List<Transaction> _transactions = TransactionExtensions.GenerateSampleTransactions();
        private List<Item> _inventory = ItemExtensions.BuildSampleInventory();

        #endregion


        #region Public Methods

        // POST api/<controller>
        [HttpPost, Authorize]
        public HttpStatusCode Post([FromBody]PurchaseOrder purchaseOrder)
        {
            // Grab current users information
            var currentUser = HttpContext.User;

            Transaction transaction = new Transaction();

            // Check to see if the user identity has been validated and snag UserId
            if (currentUser.Claims.Any(c => c.Type == "UserId"))
            {
                transaction.PurchaseOrder = purchaseOrder;
                transaction.TransactionTime = DateTime.Now.ToUniversalTime();
                transaction.UserId = int.Parse(currentUser.Claims.First(i => i.Type == "UserId").Value);
            }
            else
            {
                return HttpStatusCode.Forbidden;
            }

            // Grab user that is associated with the transaction
            User transactionUser = _users.First(u => u.UserId == transaction.UserId);

            // Grab the item price that is associated with the purchase item
            int itemPrice = _inventory.First(i => i.ItemId == purchaseOrder.ItemId).Price;

            // Validate transaction
            bool isValidTransaction = TransactionExtensions.ValidateTransaction(transaction, transactionUser.AccountBalance, itemPrice);

            if (isValidTransaction)
            {
                // Decrement account balance in DB
                transactionUser.AccountBalance = (transactionUser.AccountBalance - (transaction.PurchaseOrder.Quantity * itemPrice));

                // Add transaction in DB | DB would increment the transactionID up
                _transactions.Add(transaction);

                // Return successful response
                return HttpStatusCode.Accepted;
            }

            // Return failed response
            return HttpStatusCode.Forbidden;
        }

        #endregion
    }
}
