namespace Bank.WebApi.Models.DTOs
{
    public class ReturnAccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Balance { get; set; }
        public string Type { get; set; } = "Saving";
    }
}
