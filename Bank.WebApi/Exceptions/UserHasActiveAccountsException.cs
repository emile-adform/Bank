namespace Bank.WebApi.Exceptions
{
    public class UserHasActiveAccountsException : Exception
    {
        public UserHasActiveAccountsException() : base("User still has active accounts") { }

    }
}
