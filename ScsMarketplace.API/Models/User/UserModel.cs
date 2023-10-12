namespace ScsMarketplace.API.Models.Account
{
    public class UserModel
    {
        public int Id { get; set; }
        public int UsertypeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int LenderId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string SessionId { get; set; }
    }
}
