namespace Bank.WebApi.Models.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Balance { get; set; } = 0;
        public string Type { get; set; } = "Saving";
    }
}
