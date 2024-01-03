namespace Bank.WebApi.Exceptions
{
    public class MaxNumberOfAccountsReachedException : Exception
    {
        public MaxNumberOfAccountsReachedException() : base("User already has 2 accounts") { }

    }
}
