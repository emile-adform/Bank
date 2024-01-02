namespace Bank.WebApi.Models.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
