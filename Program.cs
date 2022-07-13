using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Object Instantiating
            Account account = new Account(); // Establishing our one client
            Checking checking = new Checking(2000); // Checking account     
            Savings savings = new Savings(10000); // Savings account           

            // Client and account name string parameters for streamwriter   
            string streamclientinfo = (account.AccountInfo());
            string checkingaccounttype = (checking.AccountType);
            string savingsaccounttype = (savings.AccountType);

            IList<string> checkingSummary = new List<string>();
            IList<string> savingsSummary = new List<string>();

            checkingSummary.Add(checkingaccounttype);
            checkingSummary.Add(streamclientinfo);

            savingsSummary.Add(savingsaccounttype);
            savingsSummary.Add(streamclientinfo);

            string userchoice = ""; // way to break out of menu do-while loop

            do
            {
                // Entries for each list that are to be done inside of the loop
                string checkingDepositEntry = ($"Transaction: +${checking.Deposit} at {DateTime.Now.ToString()} Current Balance: ${checking.Bal}");
                string checkingWithdrawalEntry = ($"Transaction: -${checking.Withdrawal} at {DateTime.Now.ToString()} Current Balance: ${checking.Bal}");
                string savingsDepositEntry = ($"Transaction: +${savings.Deposit} at {DateTime.Now.ToString()} Current Balance: ${savings.Bal}");
                string savingsWithdrawalEntry = ($"Transaction: -${savings.Withdrawal} at {DateTime.Now.ToString()} Current Balance: ${savings.Bal}");

                // Checking
                if (checking.Deposit > 0)
                {
                    checkingSummary.Add(checkingDepositEntry);
                    checking.Deposit = 0;
                }
                
                if (checking.Withdrawal > 0)
                {
                    checkingSummary.Add(checkingWithdrawalEntry);
                    checking.Withdrawal = 0;
                }

                // Savings
                if (savings.Deposit > 0)
                {
                    savingsSummary.Add(savingsDepositEntry);
                    savings.Deposit = 0;
                }
                
                if (savings.Withdrawal > 0)
                {
                    savingsSummary.Add(savingsWithdrawalEntry);
                    savings.Withdrawal = 0;
                }
               
                // Menu Online Banking -- this menu is a do-while loop with a nested switch statement.
                // Choices are Client Info, Account Info for each account type, Deposit (for each), Withdrawal (for each), or Exit. 

                Console.WriteLine("Hit Enter to Display Banking Menu");
                Console.ReadLine();

                account.DisplayMenu(); // The online banking menu
                userchoice = Console.ReadLine(); // User input from menu options

                switch (userchoice.ToUpper())
                {
                    case "I": // Display Client Info
                        Console.Clear();
                        Console.WriteLine(account.AccountInfo());
                        break;
                    case "CB": // Display Checking Account Balance
                        Console.Clear();
                        checking.Balance();
                        Console.WriteLine("Checking Account Balance: $" + checking.Bal);
                        break;
                    case "SB": // Display Savings Account Balance
                        Console.Clear();
                        savings.Balance();
                        Console.WriteLine("Savings Account Balance: $" + savings.Bal);
                        break;
                    case "CD": // Checking Account Deposit
                        Console.Clear();
                        Console.WriteLine("How much would you like to deposit?");
                        checking.Deposit = double.Parse(Console.ReadLine());
                        Console.WriteLine("You deposited: $" + checking.Deposit);
                        checking.DepositBalance(checking.Deposit);
                        break;
                    case "SD": //Savings Account Deposit
                        Console.Clear();
                        Console.WriteLine("How much would you like to deposit?");
                        savings.Deposit = double.Parse(Console.ReadLine());
                        Console.WriteLine("You deposited: $" + savings.Deposit);
                        savings.DepositBalance(savings.Deposit);
                        break;
                    case "CW": // Checking Account Withdrawal
                        Console.Clear();
                        Console.WriteLine("How much would you like to withdraw?");
                        checking.Withdrawal = double.Parse(Console.ReadLine());
                        Console.WriteLine("You withdrew: $" + checking.Withdrawal);
                        checking.WithBalance(checking.Withdrawal);
                        break;
                    case "SW": // Savings Account Withdrawal
                        Console.Clear();
                        Console.WriteLine("How much would you like to withdraw?");
                        savings.Withdrawal = double.Parse(Console.ReadLine());
                        Console.WriteLine("You withdrew: $" + savings.Withdrawal);
                        savings.WithBalance(savings.Withdrawal);
                        break;
                    case "X": // Exit Banking
                        Console.Clear();
                        account.WriteSummary(checkingSummary, "Checking");
                        account.WriteSummary(savingsSummary, "Savings");
                        Console.WriteLine("Thanks and come again!");
                        Environment.Exit(0);
                        break;
                }
            } while (userchoice.ToUpper() != "X");
        }
    }
}
