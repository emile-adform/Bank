namespace Bank.WebApi.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<AccountEntity> Accounts { get; set; }

    }
}
