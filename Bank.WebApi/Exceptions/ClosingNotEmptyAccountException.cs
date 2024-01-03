namespace Bank.WebApi.Exceptions
{
    public class ClosingNotEmptyAccountException : Exception
    {
        public ClosingNotEmptyAccountException() : base("Cannot delete account if the balance is not 0") { }

    }
}
