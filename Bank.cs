///Author: Christian Bazoian
///Date: February 21, 2018

using System.Collections.Generic;

namespace BankLedgerApp
{
    /// <summary>
    /// Bank class that holds all the users' accounts.
    /// </summary>
    public class Bank
    {
        //a list of all accounts in the bank
        private List<Account> Accounts;

        //the currently logged in account
        public Account CurrAcct { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Bank()
        {
            Accounts = new List<Account>();
            CurrAcct = null;
        }


        /// <summary>
        /// Add a new account to the bank.
        /// </summary>
        /// <param name="fname">The first name.</param>
        /// <param name="lname">The last name.</param>
        /// <param name="acctNum">The account number.</param>
        /// <param name="password">The account password.</param>
        /// <returns>True if successful, false if account number already exists.</returns>
        public bool CreateAccount(string fname, string lname, int acctNum, string password)
        {
            Account newAccount = new Account(fname, lname, acctNum, password);

            //check if account already exists
            foreach (Account account in Accounts)
            {
                if (account.AccountNumber == acctNum)
                    return false;
            }
            Accounts.Add(newAccount);
            return true;
        }


        /// <summary>
        /// Deletes an account from the list of accounts that the bank holds.
        /// </summary>
        /// <returns>true if successful, false otherwise.</returns>
        public bool DeleteAccount()
        {
            if (Accounts.Contains(CurrAcct))
            {
                Logout();
                Accounts.Remove(CurrAcct);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Logs in the provided account credentials.
        /// </summary>
        /// <param name="accountNum">Account number.</param>
        /// <param name="passwrd">Account password.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool Login(int accountNum, string passwrd)
        {
            foreach (Account account in Accounts)
            {
                if ((account.AccountNumber == accountNum))
                    if (account.Password.Equals(passwrd))
                    {
                        CurrAcct = account;
                        return true;
                    }
            }
            return false;
        }

        /// <summary>
        /// Logs out the current account.
        /// </summary>
        public void Logout()
        {
            CurrAcct = null;
        }

    }
}
