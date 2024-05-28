namespace TFWebApi.Data
{
    public class BankAccount
    {
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            if(amount < 0)
                throw new ArgumentException("Amount must be positive");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount must be positive");

            if(Balance < amount)
                throw new InvalidOperationException("Insufficient funds");

            Balance -= amount;
        }
    }
}
