namespace Bank.WebApi.Models.Entities
{
    public class AccountEntity
    {
        public enum AccountType
        {
            Savings,
            Default
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Balance { get; set; }
        public AccountType Type { get; set; }
    }
}
