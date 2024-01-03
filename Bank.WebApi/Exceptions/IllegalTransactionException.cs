namespace Bank.WebApi.Exceptions
{
    public class IllegalTransactionException : Exception
    {
        public IllegalTransactionException() : base("The transaction to the same account is not possible") { }

    }
}
