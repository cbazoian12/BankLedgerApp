///Author: Christian Bazoian
///Date: February 21, 2018

using System;
using System.Collections.Generic;

namespace BankLedgerApp
{
    /// <summary>
    /// An account class that holds all the user's information.
    /// </summary>
    public class Account
    {
        public string FirstName { get; set; }
        private string LastName { get; set; }
        public int AccountNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        private List<Transaction> TransactionHistory { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fname">First name.</param>
        /// <param name="lname">Last name.</param>
        /// <param name="acctnum">User name.</param>
        /// <param name="passwd">Password.</param>
        public Account(string fname, string lname, int acctnum, string passwd)
        {
            FirstName = fname;
            LastName = lname;
            AccountNumber = acctnum;
            Password = passwd;
            TransactionHistory = new List<Transaction>();
            Balance = 0.00;
        }


        /// <summary>
        /// Adds funds to the current acount.
        /// </summary>
        /// <param name="funds">The amount to add.</param>
        /// <returns>true if successful, false otherwise.</returns>
        public bool Deposit(double funds)
        {
            Balance += funds;
            RecordTransaction(funds, Transaction.Type.Deposit);
            return true;
        }


        /// <summary>
        /// Withdraws funds from current acount.
        /// </summary>
        /// <param name="funds">The amount to withdraw.</param>
        /// <returns>true if successful, false otherwise.</returns>
        public bool Withdraw(double funds)
        {
            if (Balance >= funds)
            {
                Balance -= funds;
                RecordTransaction(funds, Transaction.Type.Withdrawl);
                return true;
            }

            else
                return false;
        }


        /// <summary>
        /// Adds the current Transaction to the Transaction History for this account.
        /// </summary>
        /// <param name="amt">The amount of money.</param>
        /// <param name="action">Withdrawl or Deposit.</param>
        private void RecordTransaction(double amt, Transaction.Type action)
        {
            Transaction newTransaction = new Transaction(amt, action);
            TransactionHistory.Add(newTransaction);
        }


        /// <summary>
        /// Prints the transaction history for the current account.
        /// </summary>
        /// <returns>A formatted string containing the transaction history.</returns>
        public string ViewTransactionList()
        {
            string transactions = "\n Date                     Type         Amount\n";

            if (TransactionHistory.Count < 0)
                return " There are no transactions yet.";

            else
            {
                foreach (Transaction transaction in TransactionHistory)
                {
                    transactions += String.Format(" {0} ... {1}     ${2}\n", transaction.Date,
                        transaction.TransactionType, transaction.Amount.ToString("#.00",
                        System.Globalization.CultureInfo.InvariantCulture));
                }
                return transactions;
            }
        }
    }
}

