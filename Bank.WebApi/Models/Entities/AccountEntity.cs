namespace Bank.WebApi.Models.Entities
{
    public class AccountEntity
    {
        public enum AccountType
        {
            Saving,
            Default
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Balance { get; set; } = 0;
        public AccountType Type { get; set; }
    }
}
