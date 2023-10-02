using System;
namespace ScsMarketplace.API.Models.Account
{
	public class AccountModel
	{
		public long id { get; set; }
		public long consumerId { get; set; }
		public long productId { get; set; }
		public string? name { get; set; }
		public string? depositAcct { get; set; }
		public DateTimeOffset collectedDate {get; set;}
		public DateTimeOffset denied { get; set; }
		public long listingId { get; set; }
	}
}

