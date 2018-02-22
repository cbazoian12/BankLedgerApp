///Author: Christian Bazoian
///Date: February 21, 2018

using System;

namespace BankLedgerApp
{
    class Program
    {
        /// <summary>
        /// A method to display the bank ledger's initial options for the customer.
        /// </summary>
        /// <param name="bank">The bank object.</param>
        static void DisplayInitialOptions(Bank bank)
        {
            //display initial options
            Console.WriteLine("\n Welcome to the Bank Ledger.\n\n"
                + " The following options are available:\n"
                + " 1. Create a new account\n"
                + " 2. Log into an existing account\n"
                + " 3. Exit\n\n"
                + " Please press a number and then press \"Enter\"\n\n");

            //Read user input
            string input = Console.ReadLine();
            int inputAsNum;
            try
            {
                //try to parse the user's input as a number
                inputAsNum = Int32.Parse(input);
                string accountNum, accountPass, fname, lname;
                bool successful;

                switch (inputAsNum)
                {
                    case 1:  //create a new account and log in.
                        Console.Clear();
                        Console.WriteLine("\n Please enter an account number and press \"Enter.\"\n");
                        accountNum = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n Please enter a new password for your account and press \"Enter.\"\n");
                        accountPass = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n Please enter your first name and press \"Enter.\"\n");
                        fname = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n Please enter your last name and press \"Enter.\"\n");
                        lname = Console.ReadLine();
                        Console.Clear();

                        //create the new account and add to the bank
                        if (bank.CreateAccount(fname, lname, Int32.Parse(accountNum), accountPass))
                        {
                            successful = bank.Login(Int32.Parse(accountNum), accountPass);
                            if (successful)
                                Console.WriteLine("\n Hello {0}.\n", bank.CurrAcct.FirstName);
                            else
                                Console.WriteLine("\n Error creating account.\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n Error: Account number already exists. Press any key to continue.");
                            Console.ReadKey();
                        }
                        break;

                    case 2: //log into an existing account
                        Console.Clear();
                        Console.WriteLine("\n Please enter your account number.\n");
                        accountNum = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("\n Please enter your account password.\n");
                        accountPass = Console.ReadLine();
                        Console.Clear();
                        successful = bank.Login(Int32.Parse(accountNum), accountPass);
                        if (successful)
                            Console.WriteLine("\n Hello {0}.\n", bank.CurrAcct.FirstName);
                        else
                            Console.WriteLine("\n Error logging in.\n");
                        break;

                    case 3: //Exit applicaiton
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n You have entered invalid input.\n");
                        break;
                }
                //display the next set of options
                DisplaySecondaryOptions(bank);
            }
            catch (Exception e)
            {
                //invalid input was entered
                Console.Clear();
                Console.WriteLine("\n Error: Invalid input. Press any key to continue.\n");
                Console.ReadKey();
                Console.Clear();
                DisplayInitialOptions(bank);
            }
        }


        /// <summary>
        /// A method to display the bank ledger's secondary options once an account has logged in.
        /// </summary>
        /// <param name="bank">The current bank object.</param>
        static void DisplaySecondaryOptions(Bank bank)
        {
            Console.WriteLine("\n Current funds: ${0}.\n\n"
                + " Here are your options:\n"
                + " 1. Deposit Funds\n"
                + " 2. Withdraw Funds\n"
                + " 3. View Transaction History\n"
                + " 4. Log out\n", bank.CurrAcct.Balance);

            //read in the user's input
            string input = Console.ReadLine();
            int inputAsNum;
            string amount;
            bool successful;

            try
            {
                //try to parse the string input as a number
                inputAsNum = Int32.Parse(input);
                switch (inputAsNum)
                {
                    case 1: //deposit funds
                        Console.Clear();
                        Console.WriteLine("\n Please enter the amount you would like to deposit:\n");
                        amount = Console.ReadLine();
                        successful = bank.CurrAcct.Deposit(Convert.ToDouble(amount));
                        Console.Clear();
                        if (successful)
                            Console.WriteLine("\n Money deposited successfully.\n");
                        else
                            Console.WriteLine("\n Error depositing money.\n");
                        break;

                    case 2: //withdraw funds
                        Console.Clear();
                        Console.WriteLine("\n Please enter the amount you would like to withdraw:\n");
                        amount = Console.ReadLine();
                        successful = bank.CurrAcct.Withdraw(Convert.ToDouble(amount));
                        Console.Clear();
                        if (successful)
                            Console.WriteLine("\n Money withdrawl successful.\n");
                        else
                            Console.WriteLine("\n Error withdrawing money.\n");
                        break;

                    case 3: //view transaction history
                        Console.Clear();
                        Console.WriteLine(bank.CurrAcct.ViewTransactionList());
                        break;

                    case 4: //log out
                        Console.Clear();
                        bank.Logout();
                        DisplayInitialOptions(bank);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n You have entered invalid input.\n");
                        break;
                }
                //display the last set of options for the user to either continue or log out
                DisplayFinalOptions(bank);
            }
            catch (Exception e)
            {
                //invalid input was entered
                Console.Clear();
                Console.WriteLine("\n Error: Invalid input. Press any key to continue.\n");
                Console.ReadKey();
                Console.Clear();
                DisplaySecondaryOptions(bank);
            }
        }


        /// <summary>
        /// A method to display the options after the user has made a transaction.
        /// </summary>
        /// <param name="bank">The current bank object.</param>
        static void DisplayFinalOptions(Bank bank)
        {
            Console.WriteLine("\n 1. New Transaction.\n 2. Log out.\n");

            //read in user's input
            string input = Console.ReadLine();
            int inputAsNum;
            try
            {
                //try to parse the input as a number
                inputAsNum = Int32.Parse(input);
                switch (inputAsNum)
                {
                    case 1: //start a new transaction
                        Console.Clear();
                        DisplaySecondaryOptions(bank);
                        break;
                    case 2: // log out and start over from the beginning
                        Console.Clear();
                        bank.Logout();
                        DisplayInitialOptions(bank);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                //invalid input
                Console.Clear();
                Console.WriteLine("\n Error: Invalid input. Press any key to continue.\n");
                Console.ReadKey();
                Console.Clear();
                DisplayFinalOptions(bank);

            }
        }


        /// <summary>
        /// Main method.
        /// </summary>
        static void Main()
        {
            //create a new bank to hold accounts
            Bank bank = new Bank();

            DisplayInitialOptions(bank);

            Console.WriteLine("\n Press any key to exit.\n");
            Console.ReadKey();
        }
    }
}
