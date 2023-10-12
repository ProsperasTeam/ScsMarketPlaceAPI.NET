namespace UserService.Models.Account
{
    public class AccountModel
    {
        public long id { get; set; }
        public long consumerid { get; set; }
        public long productid { get; set; }
        public string? name { get; set; }
        public string? depositacct { get; set; }
        public DateTimeOffset? collecteddate { get; set; }
        public DateTimeOffset? denied { get; set; }
        public long? listingid { get; set; }
    }
}
