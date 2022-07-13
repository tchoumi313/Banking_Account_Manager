namespace BankAccount
{
    class Savings : Account
    {
        // Constructor
        public Savings(double balance) : base()
        {
            this.balance = balance;
            accountType = "Savings Account";
        }
    }
}
