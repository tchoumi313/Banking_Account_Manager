using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccount
{
    class Account
    {
        // Fields
        private string firstName;
        private string lastName;

        protected string accountType;

        protected double balance;
        private double deposit;
        private double withdrawal;

        // Properties
        public string AccountType
        { get { return this.accountType; } }

        public double Withdrawal
        {
            get { return this.withdrawal; }
            set { this.withdrawal = value; }
        }
        public double Deposit
        {
            get { return this.deposit; }
            set { this.deposit = value; }
        }

        public double Bal
        { get { return this.balance; } }

        // Constructors
        public Account()
        {
            firstName = "Jayne";
            lastName = "Smith";
        }

        // Methods
        // Computes General Balance (resets values)
        public void Balance()
        {
            balance = balance + deposit - withdrawal;
            deposit = 0;
            withdrawal = 0;
        }
        
        // Computers Balance when withdrawal equals zero
        public void DepositBalance(double input)
        {
            deposit = input;
            withdrawal = 0;
            balance = balance + deposit - withdrawal;
        }

        // Computers balance when deposit equals zero
        public void WithBalance(double input)
        {
            withdrawal = input;
            deposit = 0;
            balance = balance + deposit - withdrawal;
        }

        // Displays online banking menu
        public void DisplayMenu()
        {           
            Console.WriteLine("Please select an option below:");
            Console.WriteLine("[I] View Account Holder Information");
            Console.WriteLine("[CB] Checking - View Balance");
            Console.WriteLine("[CD] Checking - Deposit Funds");
            Console.WriteLine("[CW] Checking - Withdraw Funds");
            Console.WriteLine("[SB] Savings - View Balance");
            Console.WriteLine("[SD] Savings - Deposit Funds");
            Console.WriteLine("[SW] Savings - Withdraw Funds");
            Console.WriteLine("[X] Exit");
        }
        
        // Account info
        public string AccountInfo()
        {
            string accountInfo = ("Account Holder: " + firstName + " " + lastName);
            return accountInfo;
        }

        // Write out all trasactions to log file. 
        public void WriteSummary(IList<string> transactions, string fileName)
        {
            using (StreamWriter summary = new StreamWriter(fileName + ".txt", true))
            {
                foreach (string transaction in transactions)
                {
                    summary.WriteLine(transaction);
                }
            }
        }
    }
}
