namespace Bank.WebApi.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("Account does not have enough money for this transaction") { }

    }
}
