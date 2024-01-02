namespace Bank.WebApi.Models.DTOs
{
    public class CreateAccount
    {
        public enum AccountType
        {
            Saving,
            Default
        }
        public int UserId { get; set; }
        public AccountType Type { get; set; }
    }
}
