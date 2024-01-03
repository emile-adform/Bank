namespace Bank.WebApi.Exceptions
{
    public class IllegalAmountException : Exception
    {
        public IllegalAmountException() : base("The amount must be greater than 0"){ }

    }
}
