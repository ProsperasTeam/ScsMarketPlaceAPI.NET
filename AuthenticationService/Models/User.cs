using System;
namespace AuthenticationService.Models
{
    public class User
    {
        public int id { get; set; }
        public int? usertypeid { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modified { get; set; }
        public int? lenderid { get; set; }
        public string sessionid { get; set; }
        public string? consumeruuid { get; set; }
    }
}

