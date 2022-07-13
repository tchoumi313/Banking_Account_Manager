namespace BankAccount
{
    class Checking : Account
    {
        // Constructor
        public Checking(double balance)
        {
            this.balance = balance;
            accountType = "Checking Account";
        }
    }
}
