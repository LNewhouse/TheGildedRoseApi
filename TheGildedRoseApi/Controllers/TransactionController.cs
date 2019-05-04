using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public TransactionController()
        {
            Users = _users;
            Transactions = _transactions;
        }

        // POST api/<controller>
        [HttpPost]
        public HttpStatusCode Post([FromBody]Transaction transaction)
        {
            // Grab user that is associated with the transaction
            User transactionUser = Users.First(u => u.UserId == transaction.UserId);

            // Validate transaction
            bool isValidTransaction = TransactionExtensions.ValidateTransaction(transaction, transactionUser.AccountBalance);

            if (isValidTransaction)
            {
                // Decrement account balance in DB
                transactionUser.AccountBalance = (transactionUser.AccountBalance - (transaction.Quantity * transaction.ItemPrice));

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
    }
}
