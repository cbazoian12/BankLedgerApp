///Author: Christian Bazoian
///Date: February 21, 2018

using System;

namespace BankLedgerApp
{
    //A transaction class that holds all the details of a single transaction.
    public class Transaction
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public enum Type { Withdrawl, Deposit };
        public Type TransactionType { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="amt">The amount of the transaction.</param>
        /// <param name="action">An enum stating whether this is a Deposit or Withdrawl.</param>
        public Transaction(double amt, Type action)
        {
            Date = DateTime.Now;
            Amount = amt;
            TransactionType = action;
        }
    }
}
